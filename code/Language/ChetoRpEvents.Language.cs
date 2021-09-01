using ChetoRp.Language;

namespace ChetoRp
{
	/// <summary>
	/// A static partial class containing constant event names.
	/// </summary>
	public static partial class GameEvents
	{
		/// <summary>
		/// The name of the event run when there is a language change.
		/// <para/>
		/// Event Parameters:<br/>
		/// <see cref="LanguageType"/> oldLanguage - The language that the game is switching from..<br/>
		/// <see cref="LanguageType"/> newLanguage - The language that the game is switching to.
		/// </summary>
		public const string OnLanguageChange = "OnLanguageChange";
	}
}
