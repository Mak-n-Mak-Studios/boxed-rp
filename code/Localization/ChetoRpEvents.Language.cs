using ChetoRp.Localization;

namespace ChetoRp
{
	/// <summary>
	/// A static partial class containing constant event names.
	/// </summary>
	public static partial class GameEvents
	{
		/// <summary>
		/// The name of the event run when there is a locale change.
		/// <para/>
		/// Event Parameters:<br/>
		/// <see cref="LocaleType"/> oldLocale - The locale that the game is switching from..<br/>
		/// <see cref="LocaleType"/> newLocale - The locale that the game is switching to.
		/// </summary>
		public const string OnLocaleChange = "OnLocaleChange";
	}
}
