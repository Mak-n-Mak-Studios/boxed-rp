﻿using System;
using System.Collections.Generic;
using System.Linq;

using Sandbox;

namespace ChetoRp.Localization
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

			ILocale currentLocale = LocalizationModule.Locale;

			foreach ( T property in properties )
			{
				if ( property.PropertyType != typeof( string ) )
				{
					throw new Exception( $"The property {property.Name} in {typeof( ILocale ).FullName} is not a string" );
				}

				propertyToData.Add( property.Name, property.GetValue<string>( currentLocale ) );
			}
		}

		/// <summary>
		/// Refreshes the localization data. This method is called
		/// when the locale changes.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Style", "IDE0060:Remove unused parameter", Justification = "So the usage of __ doesn't throw a warning." )]
		[Event( GameEvents.OnLocaleChange )]
		public void RefreshAllLocalizationData( LocaleType _, LocaleType __ )
		{
			foreach ( T property in properties )
			{
				propertyToData[ property.Name ] = property.GetValue<string>( LocalizationModule.Locale );
			}
		}
	}
}
