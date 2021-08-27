﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The part of the <see cref="Module{T}"/> class which deals with the config system.
	/// </summary>
	public abstract partial class Module<T> : Module where T : new()
	{
		/// <summary>
		/// The name of the folder holding the config files within the data folder.
		/// </summary>
		public const string ConfigFolderName = "cheto-rp-config";

		private static readonly JsonSerializerOptions serializerOptions = new()
		{
			AllowTrailingCommas = true,
			ReadCommentHandling = JsonCommentHandling.Skip,
			WriteIndented = true
		};
		private string configFileName;
		private string configFilePath;
		private string configDocumentation;

		/// <summary>
		/// Initializes the config store for the module with values from the config file or default values and returns it.
		/// </summary>
		/// <returns>The initialized config store.</returns>
		private void InitializeConfig()
		{
			configFileName = GetType().FullName + ".txt";
			configFilePath = ConfigFolderName + "/" + configFileName;

			FileSystem.Data.CreateDirectory( ConfigFolderName );

			BaseFileSystem configFiles = FileSystem.Data.CreateSubSystem( ConfigFolderName );

			ReadConfigStoreFromDisk();

			// Write regardless of whether the file exists or not to update any fields that are missing or get rid of outdated fields.
			WriteConfigStoreToDisk( configFilePath );

			configFiles.Watch( configFileName ).OnChangedFile += OnConfigFileModified; // TO-DO: Fix this. File watcher does not seem to be calling the event.
		}

		/// <summary>
		/// Updates the config store for the module to reflect new changes, calling the PreConfigChange and PostConfigChange.
		/// </summary>
		/// <param name="fileName">The config file's name.</param>
		private void OnConfigFileModified( string fileName )
		{
			Event.Run( ChetoRpEvents.PreConfigChange, this );

			ReadConfigStoreFromDisk();

			Event.Run( ChetoRpEvents.PostConfigChange, this );
		}

		/// <summary>
		/// Writes the contents of the config file from the disk into the config store.
		/// This will back up the config file if a JsonException is encountered or rethrow
		/// any other exceptions created, retaining the latest available ConfigStore
		/// unless none is available in which case it will be set to the default one.
		/// </summary>

		private void ReadConfigStoreFromDisk()
		{
			string fileContent = null;

			try
			{
				fileContent = FileSystem.Data.ReadAllText( configFilePath );
				ConfigStore = JsonSerializer.Deserialize<T>( fileContent, serializerOptions ) ?? new();
			}
			catch ( FileNotFoundException )
			{
				ConfigStore = new();
			}
			catch ( JsonException )
			{
				ConfigStore ??= new();

				FileSystem.Data.WriteAllText( configFilePath + ".bak", fileContent );
			}
		}

		/// <summary>
		/// Turns the type into a readable string for the end user.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>The readable string.</returns>
		private string TypeToString( Type type )
		{
			return Type.GetTypeCode( type ) switch
			{
				TypeCode.Boolean => "true or false",

				TypeCode.SByte or
				TypeCode.Byte or
				TypeCode.Int16 or
				TypeCode.UInt16 or
				TypeCode.Int32 or
				TypeCode.UInt32 or
				TypeCode.Int64 or
				TypeCode.UInt64 => "integer",

				TypeCode.Single or
				TypeCode.Double or
				TypeCode.Decimal => "integer or decimal",

				TypeCode.Char => "single character",

				TypeCode.String => "text",

				_ => null,
			};
		}

		/// <summary>
		/// Appends the documentation for a config option to the given <see cref="StringBuilder"/>.
		/// </summary>
		/// <param name="configDocBuilder">The string builder to append the config option to.</param>
		/// <param name="configOption">The config option to append.</param>
		/// <param name="enclosingObject">An instance of the object enclosing the config option.</param>
		/// <param name="tabsIn">The number of tabs in to append everything.</param>
		/// <returns>The provided <see cref="StringBuilder"/>.</returns>
		private StringBuilder AppendConfigOption<U>( StringBuilder configDocBuilder, PropertyAttribute configOption, U enclosingObject, int tabsIn )
		{
			if ( configOption is not ChetoRpConfigOptionInfoAttribute propertyInfo )
			{
				return null;
			}

			string propertyTypeString = TypeToString( propertyInfo.PropertyType );
			object propertyDefaultValue = propertyInfo.GetValue<object>( enclosingObject );
			string spaces = new( ' ', tabsIn * 4 );

			configDocBuilder.Append( spaces )
				.Append( propertyInfo.Name )
				.Append( " - " )
				.Append( propertyTypeString ?? propertyInfo.PropertyType.Name )
				.Append( ":\n\n" )
				.Append( spaces )
				.Append( propertyInfo.Description.Replace( "\n", "\n" + spaces ) )
				.Append( ":\n\n" )
				.Append( spaces )
				.Append( "Default value of " )
				.Append( propertyInfo.Name )
				.Append( ":\n" )
				.Append( spaces )
				.Append( JsonSerializer.Serialize( propertyDefaultValue, serializerOptions ).Replace( "\n", "\n" + spaces ) );

			if ( propertyTypeString == null )
			{
				configDocBuilder.Append( "\n\n\n\nLayout of " )
					.Append( propertyInfo.PropertyType.Name )
					.Append( ":\n" );

				AppendConfigObject( configDocBuilder, propertyDefaultValue, tabsIn + 1 );
			}

			return configDocBuilder;
		}

		/// <summary>
		/// Appends the documentation for a config object to the given <see cref="StringBuilder"/>.
		/// </summary>
		/// <param name="configDocBuilder">The string builder to append the config object to.</param>
		/// <param name="obj">The config object to append.</param>
		/// <param name="tabsIn">The number of tabs in to append everything.</param>
		/// <returns>A StringBuilder.</returns>
		private StringBuilder AppendConfigObject<U>( StringBuilder configDocBuilder, U obj, int tabsIn )
		{
			Type type = typeof( U );
			IReadOnlyList<PropertyAttribute> configStoreProperties = Library.GetAttribute( type )?.Properties ??
				throw new Exception( $"The config object of type {type} used in this module's config store does not have the ChetoRpConfigObject attribute on it." );

			foreach ( PropertyAttribute property in configStoreProperties )
			{
				AppendConfigOption( configDocBuilder, property, obj, tabsIn )?
					.Append( "\n\n\n" );
			}

			return configDocBuilder;
		}

		/// <summary>
		/// Writes the config store to the disk, overwriting its current contents if there are any.
		/// This will create a new config file if one is not found in the proper place, writing the documentation 
		/// first then the contents of the config store. The default path for the config file will be 
		/// data/cheto-rp-config/&lt;PATH_TO_MODULE_ENTRYPOINT_CLASS&gt;.txt.
		/// </summary>
		private void WriteConfigStoreToDisk( string filePath )
		{
			if ( configDocumentation == null )
			{
				StringBuilder configDocBuilder = new( @"/*//////////// BEGINNING OF <CONFIG NAME> DOCUMENTATION \\\\\\\\\\\\" );

				AppendConfigObject( configDocBuilder, ConfigStore, 0 )
					.Append( @"/////////////// END OF <CONFIG NAME> DOCUMENTATION \\\\\\\\\\\\\\\*/" )
					.Append( "\n\n\n\n\n" );

				configDocumentation = configDocBuilder.ToString();
			}


			FileSystem.Data.WriteAllText( filePath, configDocumentation + JsonSerializer.Serialize( ConfigStore, serializerOptions ) );
		}
	}
}
