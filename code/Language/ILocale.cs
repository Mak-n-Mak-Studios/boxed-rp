using System.Globalization;

namespace ChetoRp.Language
{
	/// <summary>
	/// The interface to implement for all localizations.
	/// </summary>
	public interface ILocale
	{

		/// <summary>Gets the culture.</summary>
		/// <value>The culture.</value>
		public CultureInfo Culture { get; }

		/// <summary>Gets the region.</summary>
		/// <value>The region.</value>
		public RegionInfo Region => new( Culture.LCID );

		/// <summary>Gets the language.</summary>
		/// <value>The language.</value>
		public LanguageType Language { get; }
	}
}
