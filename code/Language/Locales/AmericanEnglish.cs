using System.Globalization;

namespace ChetoRp.Language
{
	/// <summary>
	/// The locale information for American English.
	/// </summary>
	public class AmericanEnglish : ILocale
	{
		public CultureInfo Culture => new( "en-US" );

		public LanguageType Language => LanguageType.EnUs;
	}
}
