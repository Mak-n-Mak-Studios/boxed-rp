using Sandbox;

using System;
using System.Text.Json.Serialization;

namespace ChetoRp
{
	/// <summary>
	/// The attribute to put on all config options within classes 
	/// marked with <see cref="ChetoRpConfigObjectAttribute"/>. This includes properties
	/// that will be serialized in config objects and enum constants.
	/// An exception will be thrown on module initialization if the marked property
	/// doesn't have both a public getter and setter or has <see cref="JsonIgnoreAttribute"/>
	/// attached simultaneously. The attribute will be ignored if put on a field that isn't
	/// an enum constant or if it's put on a property or field within a class that's not
	/// a config object.
	/// </summary>
	[AttributeUsage( AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false )]
	class ChetoRpConfigOptionInfoAttribute : PropertyAttribute
	{
		/// <summary>
		/// The description of the config option that this attribute is applied to.
		/// </summary>
		public string Description { get; }

		/// <summary>
		/// Initializes a new <see cref="ChetoRpConfigOptionInfoAttribute"/>.
		/// </summary>
		/// <param name="description">The config option description.</param>
		public ChetoRpConfigOptionInfoAttribute( string description )
		{
			Description = description;
		}
	}
}
