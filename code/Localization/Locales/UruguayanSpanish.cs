using System.Globalization;

namespace ChetoRp.Localization.Locales
{
	/// <summary>
	/// The locale information for Uruguayan Spanish.
	/// </summary>
	public class UruguayanSpanish : ILocale
	{
		public CultureInfo Culture => new( "es-UY" );
		public LocaleType LocaleType => LocaleType.EsUy;

		#region Base

		public string BaseFinishedLoading => "Se cargó ChetoRP.";
		public string BaseClientJoined => "\"{0}\" se unió a la partida.";
		public string BaseFailedToLoadModule => "Module of type, {0}, failed to load."; // TO-DO: Translate.
		public string BaseConfigMinFallDamageSpeed => "The minimum speed the player needs to be going down vertically to take damage."; // TO-DO: Translate.
		public string BaseConfigFallDamageDamping => "The damping of the fall damage value. The formula for fall damage is FallSpeed / FallDamageDamping."; // TO-DO: Translate.

		#endregion

		#region Employment

		public string EmploymentWeaponDoesNotExist => "The provided team has a weapon that does not exist: \"{0}\"."; // TO-DO: Translate.
		public string EmploymentConfigSalaryPayPeriod => "The number of seconds between each salary pay period."; // TO-DO: Translate.
		public string EmploymentConfigDefaultWeapons => "The default weapons given to all players."; // TO-DO: Translate.
		public string EmploymentConfigTeams => "The teams in the game."; // TO-DO: Translate.
		public string TeamConfigCategory => "La categoría del equipo.";
		public string TeamConfigPrettyName => "El nombre para mostrar del equipo.";
		public string TeamConfigDescription => "La descripción del equipo.";
		public string TeamConfigModels => "Los modelos posibles para el equipo.";
		public string TeamConfigWeapons => "Las armas que se le dan a los del equipo cuando spawnean.";
		public string TeamConfigShouldGetDefaultWeapons => "Si se le deberían dar las armas por defecto al equipo.";
		public string TeamConfigMaxPlayers => "La cantidad máxima de jugadores que pueden ser de este equipo a la vez. 0 = sin límite.";
		public string TeamConfigSalary => "El sueldo que se le da a los jugadores después de cada período de pago.";
		public string TeamConfigIsVoteRequired => "Si se necesita votar para entrar al equipo.";
		public string TeamConfigCanBeDemoted => "Si se pueden rebajar los jugadores del equipo.";
		public string TeamConfigIsDefault => "Si el equipo por defecto debería ser este cuando se une un jugador. El primer equipo encontrado con esta configuración activada en el archivo de configuración va a ser el equipo por defecto.";
		public string TeamConfigIsSpecialTeam => "Si el equipo es especial.";

		#endregion

		#region Localization

		public string LocalizationConfigLocale => "The locale to use. By changing this option on the server, configs are regenerated into this locale but will not affect the clients' locales. The client can use the /changelanguage command."; // TO-DO: Translate.

		#endregion
	}
}
