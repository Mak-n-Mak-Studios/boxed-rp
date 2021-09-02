namespace ChetoRp.Localization
{
	/// <summary>
	/// An interface containing the name of a property within <see cref="ILocale"/>.
	/// </summary>
	public interface ILocalizationData
	{
		/// <summary>
		/// The property name within <see cref="ILocale"/> containing the localization data.
		/// </summary>
		public string PropertyName { get; }
	}
}
