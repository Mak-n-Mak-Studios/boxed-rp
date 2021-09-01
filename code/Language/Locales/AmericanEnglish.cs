using System.Globalization;

namespace ChetoRp.Language.Locales
{
	/// <summary>
	/// The locale information for American English.
	/// </summary>
	public class AmericanEnglish : ILocale
	{
		public CultureInfo Culture => new( "en-US" );

		public LanguageType Language => LanguageType.EnUs;

		public string FinishedLoading => "ChetoRP has finished loading.";
	}
}
