namespace ChetoRp
{
	/// <summary>
	/// An interface which must be implemented for all config stores used in module descendants of <see cref="OptionalModule{T}"/>. 
	/// </summary>
	public interface IOptionalConfigStore
	{
		/// <summary>
		/// Whether or not the module should be enabled.
		/// </summary>
		public bool Enabled { get; set; }
	}
}
