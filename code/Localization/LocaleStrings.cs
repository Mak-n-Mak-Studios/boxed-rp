using Sandbox;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChetoRp.Localization
{
	/// <summary>
	/// The JSON converter to serialize and deserialize <see cref="LocaleStrings"/>.
	/// </summary>
	public class LocaleStringConverter : JsonConverter<LocaleStrings>
	{
		/// <summary>
		/// Reads the given <see cref="Utf8JsonReader"/>, deserializing it to create a <see cref="LocaleStrings"/>.
		/// </summary>
		/// <param name="reader">The JSON reader.</param>
		/// <param name="_">The type to convert.</param>
		/// <param name="options">The deserialization options.</param>
		/// <returns>The deserialized <see cref="LocaleStrings"/>.</returns>
		public override LocaleStrings Read( ref Utf8JsonReader reader, Type _, JsonSerializerOptions options )
		{
			LocaleStrings deserializedObject = new()
			{
				LocalizedStrings = JsonSerializer.Deserialize<Dictionary<LocaleType, string>>( ref reader, options )
			};

			if ( !deserializedObject.LocalizedStrings.ContainsKey( default ) )
			{
				throw new JsonException( "The locale strings are missing an en-US entry." );
			}

			return deserializedObject;
		}

		/// <summary>
		/// Writes to the given <see cref="Utf8JsonWriter"/>, serializing the given <see cref="LocaleStrings"/>.
		/// </summary>
		/// <param name="writer">The JSON writer to use.</param>
		/// <param name="value">The value to serialize.</param>
		/// <param name="options">The serialization options.</param>
		public override void Write( Utf8JsonWriter writer, LocaleStrings value, JsonSerializerOptions options )
		{
			writer.WriteStartObject();

			foreach ( (LocaleType localType, string stringValue) in value.LocalizedStrings.OrderBy( pair => pair.Key ) )
			{
				writer.WriteString( localType.ToString(), stringValue );
			}

			writer.WriteEndObject();
		}
	}

	/// <summary>
	/// A JSON serializable/deserializable class containing the localization strings
	/// of a property in <see cref="ILocale"/> marked with <see cref="LocaleStringsPropertyAttribute"/>.
	/// </summary>
	[JsonConverter( typeof( LocaleStringConverter ) )]
	public class LocaleStrings
	{
		/// <summary>
		/// A dictionary linking each locale to its version of the language string.
		/// </summary>
		internal Dictionary<LocaleType, string> LocalizedStrings { get; set; }

		private static LocalizationModule localizationModule;
		private static Dictionary<string, LocaleStringsPropertyAttribute> propertyCache;

		/// <summary>
		/// Gets the current string.
		/// </summary>
		public string CurrentString => LocalizedStrings[ LocalizationModule.Locale.LocaleType ];

		/// <summary>
		/// Initializes a new instance of the <see cref="LocaleStrings"/> class. Used for JSON deserialization.
		/// </summary>
		internal LocaleStrings()
		{
			LocalizedStrings = new();
			localizationModule ??= Modules.Get<LocalizationModule>();

			if ( propertyCache == null && localizationModule != null )
			{
				propertyCache = Library.GetAttribute( typeof( ILocale ) ).Properties
								.Where( propertyAttribute => propertyAttribute is LocaleStringsPropertyAttribute )
								.Cast<LocaleStringsPropertyAttribute>()
								.ToDictionary( propertyAttribute => propertyAttribute.Name, propertyAttribute => propertyAttribute );
			}
			else if ( LocalizationModule.Locale == null )
			{
				throw new InvalidOperationException( "Couldn't initialize LocaleStrings because the language module hasn't loaded yet." );
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LocaleStrings"/> class.
		/// </summary>
		/// <param name="propertyName">The property name within <see cref="ILocale"/> to associate with this.</param>
		public LocaleStrings( string propertyName ) : this()
		{
			foreach ( LocaleType localeType in typeof( LocaleType ).GetEnumValues() )
			{
				if ( propertyCache.TryGetValue( propertyName, out LocaleStringsPropertyAttribute propertyAttribute ) )
				{
					LocalizedStrings.Add( localeType, propertyAttribute.GetValue<string>( Modules.Get<LocalizationModule>().LocaleDictionary[ localeType ] ) );
				}
				else
				{
					throw new ArgumentException( "Invalid locale string property name.", nameof( propertyName ) );
				}
			}
		}
	}
}
