using ChetoRp.Employment;

using Sandbox;

using System.Globalization;

namespace ChetoRp.Language
{
	/// <summary>
	/// The interface to implement for all localizations.
	/// </summary>
	[Library]
	public interface ILocale
	{

		/// <summary>
		/// The locale's culture.
		/// </summary>
		public CultureInfo Culture { get; }

		/// <summary>
		/// The locale's region.
		/// </summary>
		public RegionInfo Region => new( Culture.LCID );

		/// <summary>
		/// The locale's language.
		/// </summary>
		public LanguageType Language { get; }

		/// <summary>
		/// The message for when the gamemode finishes loading.
		/// </summary>
		public string FinishedLoadingMessage { get; }

		/// <summary>
		/// The message for when a player joins.
		/// </summary>
		public string ClientJoinedMessage { get; }
	}
}
