using System.Globalization;

namespace ChetoRp.Localization.Locales
{
	/// <summary>
	/// The locale information for American English.
	/// </summary>
	public class AmericanEnglish : ILocale
	{
		public CultureInfo Culture => new( "en-US" );
		public LocaleType LocaleType => LocaleType.EnUs;

		#region Punctuation

		public string ColonPlacement => "{0}:";

		#endregion

		#region Base

		public string BaseFinishedLoading => "ChetoRP has finished loading.";
		public string BaseClientJoined => "\"{0}\" has joined the game.";
		public string BaseFailedToLoadModule => "Module of type, {0}, failed to load.";
		public string BaseTrueFalse => "true/false";
		public string BaseInteger => "integer";
		public string BaseIntegerDecimal => "integer/decimal";
		public string BaseCharacter => "character";
		public string BaseText => "text";
		public string BaseDescription => "Description";
		public string BaseDefaultValueOfProperty => "Default value of {0}";
		public string BaseLayoutOfType => "Layout of {0}";
		public string BaseTypeContainsNothing => "{0} contains nothing.";
		public string BaseBeginningOfTypeDocumentation => "BEGINNING OF {0} DOCUMENTATION";
		public string BaseEndOfTypeDocumentation => "END OF {0} DOCUMENTATION";
		public string BaseLocaleStringsDescription => "LocaleStrings contains the text to use based on the language. All locale strings must have at least an EnUs mapping, which is American English.";
		public string BaseConfigMinFallDamageSpeed => "The minimum speed the player needs to be going down vertically to take damage.";
		public string BaseConfigFallDamageDamping => "The damping of the fall damage value. The formula for fall damage is FallSpeed / FallDamageDamping.";

		#endregion

		#region Employment

		public string EmploymentWeaponDoesNotExist => "The provided team, {0}, has a weapon that does not exist: \"{1}\".";
		public string EmploymentConfigSalaryPayPeriod => "The number of seconds between each salary pay period.";
		public string EmploymentConfigDefaultWeapons => "The default weapons given to all players.";
		public string EmploymentConfigTeams => "The teams in the game.";
		public string TeamConfigCategory => "The category of the team.";
		public string TeamConfigPrettyName => "The pretty name of the team.";
		public string TeamConfigDescription => "The description of the team.";
		public string TeamConfigModels => "The possible models of the players in the team.";
		public string TeamConfigWeapons => "The weapons given to players in the team on spawn.";
		public string TeamConfigShouldGetDefaultWeapons => "Whether the default weapons should be given to this team.";
		public string TeamConfigMaxPlayers => "The max number of players that can be in this team at a time. 0 = unlimited players. Will be ignored if the team is the default team.";
		public string TeamConfigSalary => "The salary given to the players in this team every pay period.";
		public string TeamConfigIsVoteRequired => "Whether a player needs to be voted into the team.";
		public string TeamConfigCanBeDemoted => "Whether players in the team can be demoted out of the team.";
		public string TeamConfigIsDefault => "Whether this team should be the default team given when a player joins. The first default team in the configuration file will be the default team.";
		public string TeamConfigTeamType => "The type of the team.";
		public string TeamConfigStringDefaultCategory => "Uncategorized";
		public string TeamConfigStringDefaultPrettyName => "";
		public string TeamConfigStringDefaultDescription => "";

		#endregion

		#region Localization

		public string LocalizationConfigLocale => "The locale to use. By changing this option on the server, configs are regenerated into this locale but will not affect the clients' locales. The client can use the /changelanguage command.";

		#endregion
	}
}
