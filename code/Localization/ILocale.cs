using System.Globalization;

using ChetoRp.Employment;

using Sandbox;

namespace ChetoRp.Localization
{
	/// <summary>
	/// The interface to implement for all locales.
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
		/// The locale type.
		/// </summary>
		public LocaleType LocaleType { get; }

		#region Base

		/// <summary>
		/// The message for when the gamemode finishes loading.
		/// </summary>
		public string FinishedLoadingMessage { get; }

		/// <summary>
		/// The message for when a player joins.
		/// </summary>
		public string ClientJoinedMessage { get; }

		/// <summary>
		/// The message for when a module fails to load.
		/// </summary>
		public string ModuleFailedToLoadMessage { get; }

		#endregion

		#region Team

		/// <summary>
		/// The message for when the team module tries to give a weapon that does not exist.
		/// </summary>
		public string WeaponDoesNotExistMessage { get; }

		/// <summary>
		/// The description of the Category option in a <see cref="TeamConfig"/>.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamCategoryOptionDescription { get; }

		/// <summary>
		/// The description of PrettyName in a <see cref="TeamConfig"/>.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamPrettyNameOptionDescription { get; }

		/// <summary>
		/// The description of the Description option in a <see cref="TeamConfig"/>.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamDescriptionOptionDescription { get; }

		/// <summary>
		/// The description of the Models option in a <see cref="TeamConfig"/>.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamModelsOptionDescription { get; }

		/// <summary>
		/// The description of the Weapons option in a <see cref="TeamConfig"/>.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamWeaponsOptionDescription { get; }

		/// <summary>
		/// The description of the ShouldGetDefaultWeapons option in a <see cref="TeamConfig"/>.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamShouldGetDefaultWeaponsOptionDescription { get; }

		/// <summary>
		/// The description of the MaxPlayers option in a <see cref="TeamConfig"/>.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamMaxPlayersOptionDescription { get; }

		/// <summary>
		/// The description of the TeamSalary option in a <see cref="TeamConfig"/>.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamSalaryOptionDescription { get; }

		/// <summary>
		/// The description of the IsVoteRequired option in a <see cref="TeamConfig"/>.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamIsVoteRequiredOptionDescription { get; }

		/// <summary>
		/// The description of the TeamCanBeDemoted option in a <see cref="TeamConfig"/>.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamCanBeDemotedOptionDescription { get; }

		/// <summary>
		/// The description of the IsDefault option in a <see cref="TeamConfig"/>.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamIsDefaultOptionDescription { get; }

		/// <summary>
		/// The description of the IsSpecialTeam option in a <see cref="TeamConfig"/>.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamIsSpecialTeamOptionDescription { get; }

		#endregion
	}
}
