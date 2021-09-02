using System.Globalization;

namespace ChetoRp.Language.Locales
{
	/// <summary>
	/// The locale information for Uruguayan Spanish.
	/// </summary>
	public class UruguayanSpanish : ILocale
	{
		public CultureInfo Culture => new( "es-UY" );
		public LanguageType Language => LanguageType.EsUy;

		#region Base

		public string FinishedLoadingMessage => "Se cargó ChetoRP.";
		public string ClientJoinedMessage => "\"{0}\" se unió a la partida.";
		public string ModuleFailedToLoadMessage => "Module of type, {0}, failed to load."; // TO-DO: Localize.

		#endregion

		#region Team

		public string WeaponDoesNotExistMessage => "The provided team has a weapon that does not exist: \"{0}\"."; // TO-DO: Localize.
		public string TeamCategoryOptionDescription => "La categoría del equipo.";
		public string TeamPrettyNameOptionDescription => "El nombre para mostrar del equipo.";
		public string TeamDescriptionOptionDescription => "La descripción del equipo.";
		public string TeamModelsOptionDescription => "Los modelos posibles para el equipo.";
		public string TeamWeaponsOptionDescription => "Las armas que se le dan a los del equipo cuando spawnean.";
		public string TeamShouldGetDefaultWeaponsOptionDescription => "Si se le deberían dar las armas por defecto al equipo.";
		public string TeamMaxPlayersOptionDescription => "La cantidad máxima de jugadores que pueden ser de este equipo a la vez. 0 = sin límite.";
		public string TeamSalaryOptionDescription => "El sueldo que se le da a los jugadores después de cada período de pago.";
		public string TeamIsVoteRequiredOptionDescription => "Si se necesita votar para entrar al equipo.";
		public string TeamCanBeDemotedOptionDescription => "Si se pueden rebajar los jugadores del equipo.";
		public string TeamIsDefaultOptionDescription => "Si el equipo por defecto debería ser este cuando se une un jugador. El primer equipo encontrado con esta configuración activada en el archivo de configuración va a ser el equipo por defecto.";
		public string TeamIsSpecialTeamOptionDescription => "Si el equipo es especial.";

		#endregion
	}
}
