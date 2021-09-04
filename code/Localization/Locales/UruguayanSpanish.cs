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
		public string TeamConfigTeamType => "El tipo del equipo. Ingrese \"Normal\" para cualquier equipo que no sea de uno de los tipos especiales a continuación.";
		public string TeamConfigStringDefaultCategory => "Sin categoría";
		public string TeamConfigStringDefaultPrettyName => "";
		public string TeamConfigStringDefaultDescription => "";
		public string EmploymentConfigStringCivilian => "Ciudadano";
		public string EmploymentConfigStringCivilianDescription => "Podés hacer cualquier cosa. Cometer crímenes, ser un narcotraficante o crear una tienda. El mundo es tuyo.";
		public string EmploymentConfigStringLawEnforcement => "Cuerpos policiales";
		public string EmploymentConfigStringPoliceOfficer => "Oficial de policía";
		public string EmploymentConfigStringPoliceOfficerDescription => "Tenés que hacer cumplir las leyes que crea el gobernador. Sos la base del departamento de policía.";
		public string EmploymentConfigStringUndercoverPoliceOfficer => "Policía encubierto";
		public string EmploymentConfigStringUndercoverPoliceOfficerDescription => "Tenés que hacer cumplir las leyes que crea el gobernador. Podés usar tu identidad falsa para engañar a los criminales y detenerlos cuando cometen delitos.";
		public string EmploymentConfigStringSwatOfficer => "Oficial de S.W.A.T.";
		public string EmploymentConfigStringSwatOfficerDescription => "Tenés que hacer cumplir las leyes que crea el gobernador. Te van a pedir en situaciones intensas que necesitan mucha fuerza o tácticas.";
		public string EmploymentConfigStringSwatCommander => "Comandante de S.W.A.T.";
		public string EmploymentConfigStringSwatCommanderDescription => "Tenés que hacer cumplir las leyes que crea el gobernador. Te van a pedir en situaciones intensas que necesitan mucha fuerza o tácticas. Vas a liderar a todos los oficiales de S.W.A.T.";
		public string EmploymentConfigStringPoliceChief => "Jefe de policía";
		public string EmploymentConfigStringPoliceChiefDescription => "Tenés que hacer cumplir las leyes que crea el gobernador. Vas a liderar a todos los oficiales de policía.";
		public string EmploymentConfigStringEmergencyMedicalServices => "Asistencia médica";
		public string EmploymentConfigStringParamedic => "Paramédico";
		public string EmploymentConfigStringParamedicDescription => "Tu trabajo es curar a la gente. Si alguien necesita asistencia médica, vas a verificar que está vivo y sano.";
		public string EmploymentConfigStringGovernor => "Gobernador";
		public string EmploymentConfigStringGovernorDescription => "Tu papel es liderar el estado. Vas a crear leyes y controlar toda la policía. Pero tené cuidado. Si no sos muy popular, la gente te puede destituir.";

		#endregion

		#region Localization

		public string LocalizationConfigLocale => "El idioma y región para usar. Si usted cambia esta opción en las configuraciones del servidor, se van a regenerar todos los archivos de configuración para que usen este idioma pero no va a afectar a los clientes. Para cambiar su idioma y región, los clientes pueden usar el comando /changelanguage. Ingrese un idioma y región compatible en la lista abajo. El idioma es un código ISO 639-1. La región es un código ISO 3166.";

		#endregion
	}
}
