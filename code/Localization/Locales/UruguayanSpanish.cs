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

		#region Punctuation

		public string ColonPlacement => "{0}:";

		#endregion

		#region Base

		public string BaseFinishedLoading => "Se cargó ChetoRP.";
		public string BaseClientJoined => "\"{0}\" se unió a la partida.";
		public string BaseFailedToLoadModule => "No se pudo cargar el módulo del tipo, {0}.";
		public string BaseTrueFalse => "true/false (sí/no)";
		public string BaseInteger => "integral";
		public string BaseIntegerDecimal => "integral/decimal";
		public string BaseCharacter => "carácter";
		public string BaseText => "texto";
		public string BaseDescription => "Descripción";
		public string BaseDefaultValueOfProperty => "El valor por defecto de {0}";
		public string BaseLayoutOfType => "Estructura de {0}";
		public string BaseTypeContainsNothing => "{0} no tiene nada.";
		public string BaseBeginningOfTypeDocumentation => "COMIENZO DE LA DOCUMENTACIÓN DE {0}";
		public string BaseEndOfTypeDocumentation => "FIN DE LA DOCUMENTACIÓN DE {0}";
		public string BaseLocaleStringsDescription => "LocaleStrings tiene el texto para usar en cada idioma disponible. Todos los LocaleStrings al menos tienen que tener una opción para EnUs (inglés estadounidense).";
		public string BaseConfigMinFallDamageSpeed => "La velocidad mínima para abajo que tiene que ir el jugador para dañarse.";
		public string BaseConfigFallDamageDamping => "Cuánto se va a reducir el daño de caída. La fórmula para daño de caída es Velocidad / FallDamageDamping (reducción de daño de caída).";

		#endregion

		#region Employment

		public string EmploymentWeaponDoesNotExist => "El equipo, {0}, tiene un arma que no existe: \"{1}\".";
		public string EmploymentConfigSalaryPayPeriod => "El tiempo en segundos entre cada período de pago.";
		public string EmploymentConfigDefaultWeapons => "Las armas por defecto recibidos por todos los jugadores.";
		public string EmploymentConfigTeams => "Los equipos en el juego.";
		public string TeamConfigCategory => "La categoría del equipo.";
		public string TeamConfigPrettyName => "El nombre para mostrar del equipo.";
		public string TeamConfigDescription => "La descripción del equipo.";
		public string TeamConfigModels => "Los modelos posibles para el equipo.";
		public string TeamConfigWeapons => "Las armas que se le dan a los del equipo cuando spawnean.";
		public string TeamConfigShouldGetDefaultWeapons => "Si se le deberían dar las armas por defecto al equipo.";
		public string TeamConfigMaxPlayers => "La cantidad máxima de jugadores que pueden ser de este equipo a la vez. 0 = sin límite. Se va a ignorar esta configuración si este es el equipo por defecto.";
		public string TeamConfigSalary => "El sueldo que se le da a los jugadores después de cada período de pago.";
		public string TeamConfigIsVoteRequired => "Si se necesita votar para entrar al equipo.";
		public string TeamConfigCanBeDemoted => "Si se pueden rebajar los jugadores del equipo.";
		public string TeamConfigIsDefault => "Si el equipo por defecto debería ser este cuando se une un jugador. El primer equipo encontrado con esta configuración activada en el archivo de configuración va a ser el equipo por defecto.";
		public string TeamConfigTeamType => "El tipo del equipo.";
		public string TeamConfigStringDefaultCategory => "Sin categoría";
		public string TeamConfigStringDefaultPrettyName => "";
		public string TeamConfigStringDefaultDescription => "";

		#endregion

		#region Localization

		public string LocalizationConfigLocale => "El idioma y región para usar. Si cambiás esta opción en las configuraciones del servidor, se van a regenerar todos los archivos de configuración para que usen este idioma pero no va a afectar a los clientes. Para cambiar su idioma y región, los clientes pueden usar el comando /changelanguage.";

		#endregion
	}
}
