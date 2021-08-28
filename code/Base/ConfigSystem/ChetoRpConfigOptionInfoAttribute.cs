using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The attribute to put on all config options properties within classes marked with <see cref="ChetoRpConfigObjectAttribute"/>.
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
