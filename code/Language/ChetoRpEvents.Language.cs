using ChetoRp.Language;

namespace ChetoRp
{
	/// <summary>
	/// A static partial class containing constant event names.
	/// </summary>
	public static partial class GameEvents
	{
		/// <summary>
		/// The name of the event run before a language change.
		/// <para/>
		/// Event Parameters:<br/>
		/// <see cref="LanguageType"/> oldLanguage - The language that the game is going to be changed from..<br/>
		/// </summary>
		public const string PreLanguageChange = "PreLanguageChange";

		/// <summary>
		/// The name of the event run after a language change.
		/// <para/>
		/// Event Parameters:<br/>
		/// <see cref="LanguageType"/> newLanguage - The new language that the game has switched to.
		/// </summary>
		public const string PostLanguageChange = "PostLanguageChange";
	}
}
