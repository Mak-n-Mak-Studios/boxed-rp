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

		#region Base

		public string FinishedLoadingMessage => "ChetoRP has finished loading.";
		public string ClientJoinedMessage => "\"{0}\" has joined the game.";
		public string ModuleFailedToLoadMessage => "Module of type, {0}, failed to load.";

		#endregion

		#region Team

		public string WeaponDoesNotExistMessage => "The provided team has a weapon that does not exist: \"{0}\".";
		public string TeamCategoryOptionDescription => "The category of the team.";
		public string TeamPrettyNameOptionDescription => "The pretty name of the team.";
		public string TeamDescriptionOptionDescription => "The description of the team.";
		public string TeamModelsOptionDescription => "The possible models of the players in the team.";
		public string TeamWeaponsOptionDescription => "The weapons given to players in the team on spawn.";
		public string TeamShouldGetDefaultWeaponsOptionDescription => "Whether the default weapons should be given to this team.";
		public string TeamMaxPlayersOptionDescription => "The max number of players that can be in this team at a time. 0 = unlimited players.";
		public string TeamSalaryOptionDescription => "The salary given to the players in this team every pay period.";
		public string TeamIsVoteRequiredOptionDescription => "Whether a player needs to be voted into the team.";
		public string TeamCanBeDemotedOptionDescription => "Whether players in the team can be demoted out of the team.";
		public string TeamIsDefaultOptionDescription => "Whether this team should be the default team given when a player joins. The first default team in the configuration file will be the default team.";
		public string TeamIsSpecialTeamOptionDescription => "Whether this team is a special team.";

		#endregion
	}
}
