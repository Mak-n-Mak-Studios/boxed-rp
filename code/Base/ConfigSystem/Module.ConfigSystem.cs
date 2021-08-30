using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

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
		private static string TypeToString( Type type )
		{
			type = GetArrayElementType( type, out int deep );
			StringBuilder arrayOfText = new StringBuilder( deep * 9 + 15 ).
				Insert( 0, "array of ", deep );

			if ( type == typeof( bool ) )
			{
				return arrayOfText.Append( "true/false" ).ToString();
			}
			else if ( type == typeof( uint ) || type == typeof( int ) || type == typeof( ushort ) || type == typeof( short ) ||
				type == typeof( ulong ) || type == typeof( long ) || type == typeof( byte ) || type == typeof( sbyte ) )
			{
				return arrayOfText.Append( "integer" ).ToString();
			}
			else if ( type == typeof( float ) || type == typeof( double ) || type == typeof( decimal ) )
			{
				return arrayOfText.Append( "integer/decimal" ).ToString();
			}
			else if ( type == typeof( char ) )
			{
				return arrayOfText.Append( "character" ).ToString();
			}
			else if ( type == typeof( string ) )
			{
				return arrayOfText.Append( "text" ).ToString();
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Gets the deepest element type of a given type
		/// </summary>
		/// <param name="type">The type to get the deepest element type of..</param>
		/// <param name="deep">How deep the deepest element type was.</param>
		/// <returns>The deepest element type.</returns>
		private static Type GetArrayElementType( Type type, out int deep )
		{
			deep = 0;
			Type arrayElementType = type;

			while ( arrayElementType.HasElementType )
			{
				deep++;
				arrayElementType = arrayElementType.GetElementType();
			}

			return arrayElementType;
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

			Type baseType = GetArrayElementType( propertyInfo.PropertyType, out int deep );
			string propertyPrimitiveTypeString = TypeToString( propertyInfo.PropertyType );
			string propertyCustomTypeString = null;
			string propertyCustomBaseTypeString = null;
			object propertyDefaultValue = propertyInfo.GetValue<object>( enclosingObject );
			string spaces = new( ' ', tabsIn * 4 );

			if ( propertyPrimitiveTypeString == null )
			{
				string customTypeString = propertyInfo.PropertyType.ToString();

				propertyCustomTypeString = customTypeString[ ( customTypeString.LastIndexOf( '.' ) + 1 ).. ];

				if ( deep > 0 )
				{
					string customBaseTypeString = baseType.ToString();
					propertyCustomBaseTypeString = customBaseTypeString[ ( customBaseTypeString.LastIndexOf( '.' ) + 1 ).. ];
				}
				else
				{
					propertyCustomBaseTypeString = propertyCustomTypeString;
				}
			}

			configDocBuilder.Append( spaces )
				.Append( propertyInfo.Name )
				.Append( " - " )
				.Append( propertyPrimitiveTypeString ?? propertyCustomTypeString )
				.Append( ":\n\n" )
				.Append( spaces )
				.Append( "Description:" )
				.Append( '\n' )
				.Append( spaces )
				.Append( propertyInfo.Description.Replace( "\n", "\n" + spaces ) )
				.Append( "\n\n" )
				.Append( spaces )
				.Append( "Default value of " )
				.Append( propertyInfo.Name )
				.Append( ":\n" )
				.Append( spaces )
				.Append( JsonSerializer.Serialize( propertyDefaultValue, serializerOptions ).Replace( "\n", "\n" + spaces ) );

			if ( propertyCustomTypeString != null )
			{
				configDocBuilder.Append( "\n\n-----------------------------------------------------------------\n\nLayout of " )
					.Append( propertyCustomBaseTypeString )
					.Append( ":\n" );

				if ( deep == 0 )
				{
					AppendConfigObject( configDocBuilder, propertyDefaultValue, tabsIn + 1 );
				}
				else
				{
					AppendConfigObject( configDocBuilder, baseType, tabsIn + 1 );
				}

			}

			return configDocBuilder;
		}

		/// <summary>
		/// Appends the documentation for a config object type to the given <see cref="StringBuilder"/>.
		/// This config object is assumed to not be the outer object.
		/// </summary>
		/// <param name="configDocBuilder">The string builder to append the config object to.</param>
		/// <param name="type">The config object type to append.</param>
		/// <param name="tabsIn">The number of tabs in to append everything.</param>
		/// <returns>A StringBuilder.</returns>
		private StringBuilder AppendConfigObject( StringBuilder configDocBuilder, Type type, int tabsIn )
		{
			object configObject = Library.Create<object>( type ) ??
				throw new Exception( $"The config object of type {type} used in this module's config store does not have the ChetoRpConfigObject attribute on it" );

			return AppendConfigObject( configDocBuilder, configObject, tabsIn );
		}

		/// <summary>
		/// Appends the documentation for a config object to the given <see cref="StringBuilder"/>.
		/// </summary>
		/// <param name="docBuilder">The string builder to append the config object to.</param>
		/// <param name="obj">The config object to append.</param>
		/// <param name="tabsIn">The number of tabs in to append everything.</param>
		/// <returns>A StringBuilder.</returns>
		private StringBuilder AppendConfigObject<U>( StringBuilder docBuilder, U obj, int tabsIn )
		{
			Type type = obj.GetType();
			IReadOnlyList<PropertyAttribute> configStoreProperties = Library.GetAttribute( type )?.Properties ??
				throw new Exception( $"The config object of type {type} used in this module's config store does not have the ChetoRpConfigObject attribute on it" );

			PropertyAttribute lastProperty = configStoreProperties[ ^1 ];

			foreach ( PropertyAttribute property in configStoreProperties )
			{
				try
				{
					property.SetValue( obj, property.GetValue<object>( obj ) );
				}
				catch ( MethodAccessException )
				{
					throw new Exception( $"The {property.Name} property within {type} is not both publicly gettable and settable." );
				}

				if ( property.Attributes.Where( ( attr ) => attr.GetType() == typeof( JsonIgnoreAttribute ) ).Any() )
				{
					throw new Exception( $"The {property.Name} property within {type} has [JsonIgnore] on it. This attribute is not compatible with [ChetoRpConfigOptionInfo]." );
				}

				AppendConfigOption( docBuilder, property, obj, tabsIn )?
					.Append( "\n\n" );


				if ( lastProperty != property )
				{
					docBuilder.Append( ' ', tabsIn * 4 )
						.Append( "=================================================================\n\n" );
				}
			}

			return docBuilder;
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
				string qualifiedTypeName = GetType().ToString();
				string typeName = qualifiedTypeName[ ( qualifiedTypeName.LastIndexOf( '.' ) + 1 ).. ];

				StringBuilder configDocBuilder = new StringBuilder( @$"/*//////////// BEGINNING OF {typeName} DOCUMENTATION \\\\\\\\\\\\" )
					.Append( "\n\n" );

				AppendConfigObject( configDocBuilder, ConfigStore, 0 )
					.Append( @$"/////////////// END OF {typeName} DOCUMENTATION \\\\\\\\\\\\\\\*/" )
					.Append( "\n\n\n" );

				configDocumentation = configDocBuilder.ToString();
			}

			FileSystem.Data.WriteAllText( filePath, configDocumentation + JsonSerializer.Serialize( ConfigStore, serializerOptions ) );
		}
	}
}
