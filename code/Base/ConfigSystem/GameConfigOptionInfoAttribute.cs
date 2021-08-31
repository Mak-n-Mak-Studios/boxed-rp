using System;
using System.Text.Json.Serialization;

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
	class GameConfigOptionInfoAttribute : PropertyAttribute
	{
		/// <summary>
		/// The description of the config option that this attribute is applied to.
		/// </summary>
		public string Description { get; }

		/// <summary>
		/// Initializes a new <see cref="GameConfigOptionInfoAttribute"/>.
		/// </summary>
		/// <param name="description">The config option description.</param>
		public GameConfigOptionInfoAttribute( string description )
		{
			Description = description;
		}
	}
}
