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

		public string FinishedLoadingMessage => "ChetoRP has finished loading.";
		public string ClientJoinedMessage => "\"{0}\" has joined the game.";
	}
}
