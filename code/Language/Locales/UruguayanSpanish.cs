using System.Globalization;

namespace ChetoRp.Language
{
	/// <summary>
	/// The locale information for Uruguayan Spanish.
	/// </summary>
	public class UruguayanSpanish : ILocale
	{
		public CultureInfo Culture => new( "es-UY" );

		public LanguageType Language => LanguageType.EsUy;
	}
}
