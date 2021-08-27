using Sandbox;

using System;

namespace ChetoRp
{
	/// <summary>
	/// The attribute to put on all config options properties within config stores
	/// </summary>
	class ChetoRpConfigOptionInfoAttribute : PropertyAttribute
	{
		/// <summary>
		/// The description of the config option that this attribute is applied to.
		/// </summary>
		public string Description { get; }

		/// <summary>
		/// Initializes a new<see cref="ChetoRpConfigOptionInfoAttribute"/>.
		/// </summary>
		/// <param name="description">The config option description.</param>
		public ChetoRpConfigOptionInfoAttribute( string description )
		{
			Description = description;
		}
	}
}
