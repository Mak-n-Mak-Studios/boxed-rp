using System;
using System.Text.Json.Serialization;

using ChetoRp.Language;

using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The attribute to put on all config options properties within classes 
	/// marked with <see cref="GameConfigObjectAttribute"/>.
	/// An exception will be thrown on module initialization if the marked property
	/// doesn't have both a public getter and setter or has <see cref="JsonIgnoreAttribute"/>
	/// attached simultaneously.
	/// </summary>
	[AttributeUsage( AttributeTargets.Property, AllowMultiple = false )]
	class GameConfigOptionInfoAttribute : PropertyAttribute, ILocalizationData
	{
		/// <summary>
		/// The name of the property in <see cref="ILocale"/> containing the 
		/// localized description of this config option.
		/// </summary>
		public string PropertyName { get; }

		/// <summary>
		/// Initializes a new <see cref="GameConfigOptionInfoAttribute"/>.
		/// </summary>
		/// <param name="propertyName">The name of the property in <see cref="ILocale"/> 
		/// containing the localized description of this config option.</param>
		public GameConfigOptionInfoAttribute( string propertyName )
		{
			PropertyName = propertyName;
		}
	}
}
