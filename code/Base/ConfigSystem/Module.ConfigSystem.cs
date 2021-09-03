using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using ChetoRp.Localization;

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
		public const string ConfigFolderName = "game-config";

		private static readonly JsonSerializerOptions serializerOptions = new()
		{
			AllowTrailingCommas = true,
			ReadCommentHandling = JsonCommentHandling.Skip,
			WriteIndented = true
		};

		private LocalizationManager<ConfigLocalizedPropertyAttribute> localizedConfigOptions;
		private string configFileName;
		private string configFilePath;
		private string configDocumentation;

		/// <summary>
		/// Initializes the config store for the module with values from the config file or default values and returns it.
		/// </summary>
		/// <returns>The initialized config store.</returns>
		private void InitializeConfig()
		{
			if ( localizedConfigOptions == null )
			{
				localizedConfigOptions = new();
			}

			configFileName = GetType().FullName + ".txt";
			configFilePath = ConfigFolderName + "/" + configFileName;

			FileSystem.Data.CreateDirectory( ConfigFolderName );

			BaseFileSystem configFiles = FileSystem.Data.CreateSubSystem( ConfigFolderName );

			ReadConfigStoreFromDisk();

			// Write regardless of whether the file exists or not to update any fields that are missing or get rid of outdated fields.
			WriteConfigStoreToDisk( configFilePath );

			if ( typeof( T ) != typeof( LocalizationModuleConfig ) )
			{
				// A bit of a hack to refresh localization data manually for the localization config

				localizedConfigOptions.RefreshAllLocalizationData( default, default );
				WriteConfigStoreToDisk( configFilePath );
			}

			configFiles.Watch( configFileName ).OnChangedFile += OnConfigFileModified; // TO-DO: Fix this. File watcher does not seem to be calling the event.
		}

		/// <summary>
		/// Refreshes the config file on a locale change to change its locale.
		/// </summary>
		[Event( GameEvents.OnLocaleChange )]
		protected virtual void ReLocalizeConfigFile( LocaleType _, LocaleType __ )
		{
			WriteConfigStoreToDisk( configFilePath );
		}

		/// <summary>
		/// Updates the config store for the module to reflect new changes, calling the PreConfigChange and PostConfigChange.
		/// </summary>
		/// <param name="fileName">The config file's name.</param>
		protected virtual void OnConfigFileModified( string fileName )
		{
			Event.Run( GameEvents.PreConfigChange, this );

			ReadConfigStoreFromDisk();

			Event.Run( GameEvents.PostConfigChange, this );
		}

		/// <summary>
		/// Writes the contents of the config file from the disk into the config store.
		/// This will back up the config file if a JsonException is encountered or rethrow
		/// any other exceptions created, retaining the latest available ConfigStore
		/// unless none is available in which case it will be set to the default one.
		/// </summary>
		protected virtual void ReadConfigStoreFromDisk()
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
			StringBuilder arrayOfText = new( 25 + deep * 2 ); // deep * 2 = how deep the array is * "[]" length. Add 25 for the length of the type string in the array.

			if ( type == typeof( bool ) )
			{
				arrayOfText.Append( LocalizationModule.Locale.BaseTrueFalse );
			}
			else if ( type == typeof( uint ) || type == typeof( int ) || type == typeof( ushort ) || type == typeof( short ) ||
				type == typeof( ulong ) || type == typeof( long ) || type == typeof( byte ) || type == typeof( sbyte ) )
			{
				arrayOfText.Append( LocalizationModule.Locale.BaseInteger );
			}
			else if ( type == typeof( float ) || type == typeof( double ) || type == typeof( decimal ) )
			{
				arrayOfText.Append( LocalizationModule.Locale.BaseIntegerDecimal );
			}
			else if ( type == typeof( char ) )
			{
				arrayOfText.Append( LocalizationModule.Locale.BaseCharacter );
			}
			else if ( type == typeof( string ) )
			{
				arrayOfText.Append( LocalizationModule.Locale.BaseText );
			}
			else
			{
				return null;
			}

			return arrayOfText.Insert( arrayOfText.Length, "[]", deep ).ToString();
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
		protected virtual StringBuilder AppendConfigOption<U>( StringBuilder configDocBuilder, PropertyAttribute configOption, U enclosingObject, int tabsIn )
		{
			if ( configOption is not GameConfigOptionInfoAttribute propertyInfo )
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

			try
			{
				configDocBuilder.Append( spaces )
					.Append( propertyInfo.Name )
					.Append( " - " )
					.Append( LocalizationModule.Locale.ColonPlacement.Format( propertyPrimitiveTypeString ?? propertyCustomTypeString ) )
					.Append( "\n\n" )
					.Append( spaces )
					.Append( LocalizationModule.Locale.ColonPlacement.Format( LocalizationModule.Locale.BaseDescription ) )
					.Append( '\n' )
					.Append( spaces )
					.Append( localizedConfigOptions[ propertyInfo ].Replace( "\n", "\n" + spaces ) )
					.Append( "\n\n" )
					.Append( spaces )
					.Append( LocalizationModule.Locale.ColonPlacement.Format( LocalizationModule.Locale.BaseDefaultValueOfProperty.Format( propertyInfo.Name ) ) )
					.Append( '\n' )
					.Append( spaces )
					.Append( JsonSerializer.Serialize( propertyDefaultValue, serializerOptions ).Replace( "\n", "\n" + spaces ) );
			}
			catch ( KeyNotFoundException )
			{
				throw new Exception( "The property name given on the [ConfigLocalizedProperty] attribute on the property " +
					$"{propertyInfo.Name} in {enclosingObject.GetType().FullName} isn't valid. Check that the property name " +
					"has been typed properly and that the property that the property name refers to has a subclass of the " +
					"[LocalizationDataProperty] attached to it." );
			}

			if ( propertyCustomTypeString != null )
			{
				configDocBuilder.Append( "\n\n" )
					.Append( spaces )
					.Append( "-----------------------------------------------------------------\n\n" )
					.Append( spaces )
					.Append( LocalizationModule.Locale.ColonPlacement.Format( LocalizationModule.Locale.BaseLayoutOfType.Format( propertyCustomBaseTypeString ) ) )
					.Append( '\n' );

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
		protected virtual StringBuilder AppendConfigObject( StringBuilder configDocBuilder, Type type, int tabsIn )
		{
			object configObject = Library.Create<object>( type ) ??
				throw new Exception( $"The config object of type {type} used in this module's config store does not have the GameConfigObject attribute on it." );

			return AppendConfigObject( configDocBuilder, configObject, tabsIn );
		}

		/// <summary>
		/// Appends the documentation for a config object to the given <see cref="StringBuilder"/>.
		/// </summary>
		/// <param name="docBuilder">The string builder to append the config object to.</param>
		/// <param name="obj">The config object to append.</param>
		/// <param name="tabsIn">The number of tabs in to append everything.</param>
		/// <returns>A StringBuilder.</returns>
		protected virtual StringBuilder AppendConfigObject<U>( StringBuilder docBuilder, U obj, int tabsIn )
		{
			Type type = obj.GetType();
			string spaces = new( ' ', tabsIn * 4 );

			if ( type.IsEnum )
			{
				string[] enumNames = type.GetEnumNames();

				if ( enumNames.Length == 0 )
				{
					string typeString = type.ToString();

					return docBuilder.Append( spaces )
						.Append( LocalizationModule.Locale.BaseTypeContainsNothing.Format( typeString[ ( typeString.LastIndexOf( '.' ) + 1 ).. ] ) );
				}

				string lastEnumConstant = enumNames[ ^1 ];

				foreach ( string enumName in type.GetEnumNames() )
				{
					docBuilder.Append( spaces )
						.Append( enumName );

					if ( enumName != lastEnumConstant )
					{
						docBuilder.Append( '\n' );
					}
				}

				return docBuilder;
			}

			IReadOnlyList<PropertyAttribute> configStoreProperties = Library.GetAttribute( type )?.Properties ??
				throw new Exception( $"The config object of type {type} used in this module's config store does not have the GameConfigObject attribute on it." );

			if ( configStoreProperties.Count == 0 )
			{
				string typeString = type.ToString();

				return docBuilder.Append( spaces )
					.Append( LocalizationModule.Locale.BaseTypeContainsNothing.Format( typeString[ ( typeString.LastIndexOf( '.' ) + 1 ).. ] ) );
			}

			PropertyAttribute lastProperty = configStoreProperties[ ^1 ];

			foreach ( PropertyAttribute property in configStoreProperties )
			{
				try
				{
					property.SetValue( obj, property.GetValue<object>( obj ) );
				}
				catch ( ArgumentException )
				{
					throw new Exception( $"The {property.Name} property within {type} is not both publicly gettable and settable." );
				}

				if ( property.Attributes.Where( ( attr ) => attr.GetType() == typeof( JsonIgnoreAttribute ) ).Any() )
				{
					throw new Exception( $"The {property.Name} property within {type} has [JsonIgnore] on it. This attribute is not compatible with [GameConfigOptionInfo]." );
				}

				bool isConfigOption = AppendConfigOption( docBuilder, property, obj, tabsIn ) != null;

				if ( isConfigOption && lastProperty != property )
				{
					docBuilder.Append( "\n\n" )
						.Append( spaces )
						.Append( "=================================================================\n\n" );
				}
			}

			return docBuilder;
		}

		/// <summary>
		/// Writes the config store to the disk, overwriting its current contents if there are any.
		/// This will create a new config file if one is not found in the proper place, writing the documentation 
		/// first then the contents of the config store. The default path for the config file will be 
		/// data/game-config/&lt;PATH_TO_MODULE_ENTRYPOINT_CLASS&gt;.txt.
		/// </summary>
		protected virtual void WriteConfigStoreToDisk( string filePath )
		{
			if ( configDocumentation == null )
			{
				string qualifiedTypeName = GetType().ToString();
				string typeName = qualifiedTypeName[ ( qualifiedTypeName.LastIndexOf( '.' ) + 1 ).. ];

				StringBuilder configDocBuilder = new StringBuilder( "/*//////////// " )
					.Append( LocalizationModule.Locale.BaseBeginningOfTypeDocumentation.Format( typeName ) )
					.Append( @" \\\\\\\\\\\\" )
					.Append( "\n\n" );

				AppendConfigObject( configDocBuilder, ConfigStore, 0 )
					.Append( "\n\n" )
					.Append( @$"/////////////// " )
					.Append( LocalizationModule.Locale.BaseEndOfTypeDocumentation.Format( typeName ) )
					.Append( @" \\\\\\\\\\\\\\\*/" )
					.Append( "\n\n\n" );

				configDocumentation = configDocBuilder.ToString();
			}

			FileSystem.Data.WriteAllText( filePath, configDocumentation + JsonSerializer.Serialize( ConfigStore, serializerOptions ) );
		}
	}
}
