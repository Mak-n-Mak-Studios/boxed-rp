using Sandbox;

using System;
using System.Text.Json.Serialization;

namespace ChetoRp
{
	/// <summary>
	/// The attribute to put on all config options properties within classes 
	/// marked with <see cref="ChetoRpConfigObjectAttribute"/>.
	/// An exception will be thrown on module initialization if the marked property
	/// doesn't have both a public getter and setter or has <see cref="JsonIgnoreAttribute"/>
	/// attached simultaneously.
	/// </summary>
	[AttributeUsage( AttributeTargets.Property, AllowMultiple = false )]
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
