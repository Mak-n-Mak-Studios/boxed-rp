using System;

namespace ChetoRp
{
	/// <summary>
	/// The attribute to put on all config options properties within config stores
	/// </summary>
	[AttributeUsage( AttributeTargets.Property )]
	class ChetoRpConfigOptionDescriptionAttribute : Attribute
	{
		/// <summary>
		/// The description of the config option that this attribute is applied to.
		/// </summary>
		public string Description { get; }

		/// <summary>
		/// Initializes a new<see cref="ChetoRpConfigOptionDescriptionAttribute"/>.
		/// </summary>
		/// <param name="description">The config option description.</param>
		public ChetoRpConfigOptionDescriptionAttribute( string description )
		{
			Description = description;
		}
	}
}
