using Sandbox;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ChetoRp.Language
{
	/// <summary>
	/// The class that gives language strings based on the current locale from attributes 
	/// with property names given from their arguments.<see cref="ILocale"/>
	/// </summary>
	public class LocalizationManager<T> where T : LocalizationDataPropertyAttribute
	{
		public string this[ ILocalizationData data ] => propertyToData[ data.PropertyName ];

		private readonly List<T> properties;
		private readonly Dictionary<string, string> propertyToData;

		/// <summary>
		/// Initializes a new <see cref="LocalizationManager{T}"/>
		/// </summary>
		public LocalizationManager()
		{
			properties = Library.GetAttribute( typeof( ILocale ) ).Properties
				.Where( attr => attr is T )
				.Select( attr => attr as T )
				.ToList();

			propertyToData = new Dictionary<string, string>( properties.Count );

			foreach ( T property in properties )
			{
				if ( property.PropertyType != typeof( string ) )
				{
					throw new Exception( $"The property {property.Name} in {typeof( ILocale ).Name} is not a string" );
				}

				propertyToData.Add( property.Name, property.GetValue<string>( LanguageModule.Locale ) );
			}
		}

		/// <summary>
		/// Refreshes the localization data. This method is called
		/// when the language changes.
		/// </summary>
		[Event( GameEvents.OnLanguageChange )]
		public void RefreshAllLocalizationData( LanguageType _, LanguageType __ )
		{
			foreach ( T property in properties )
			{
				propertyToData[ property.Name ] = property.GetValue<string>( LanguageModule.Locale );
			}
		}
	}
}
