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

		#region Punctuation

		/// <summary>
		/// The colon placement in a string.
		/// </summary>
		public string ColonPlacement { get; }

		#endregion

		#region Base

		/// <summary>
		/// The message for when the gamemode finishes loading.
		/// </summary>
		public string BaseFinishedLoading { get; }

		/// <summary>
		/// The message for when a player joins.
		/// </summary>
		public string BaseClientJoined { get; }

		/// <summary>
		/// The message for when a module fails to load.
		/// </summary>
		public string BaseFailedToLoadModule { get; }

		/// <summary>
		/// The string to describe boolean types in config files.
		/// </summary>
		public string BaseTrueFalse { get; }

		/// <summary>
		/// The string to describe integer types in config files.
		/// </summary>
		public string BaseInteger { get; }

		/// <summary>
		/// The string to describe integer/decimal types in config files.
		/// </summary>
		public string BaseIntegerDecimal { get; }

		/// <summary>
		/// The string to describe character types in config files.
		/// </summary>
		public string BaseCharacter { get; }

		/// <summary>
		/// The string to describe string types in config files.
		/// </summary>
		public string BaseText { get; }

		/// <summary>
		/// The string for "Description" in config files.
		/// </summary>
		public string BaseDescription { get; }

		/// <summary>
		/// The string for "Default value of [property]" in config files.
		/// </summary>
		public string BaseDefaultValueOfProperty { get; }

		/// <summary>
		/// The string for "Layout of [type]" in config files.
		/// </summary>
		public string BaseLayoutOfType { get; }

		/// <summary>
		/// The string for "[type] contains nothing." in config files.
		/// </summary>
		public string BaseTypeContainsNothing { get; }

		/// <summary>
		/// The string for "BEGINNING OF [type] DOCUMENTATION" in config files.
		/// </summary>
		public string BaseBeginningOfTypeDocumentation { get; }

		/// <summary>
		/// The string for "END OF [type] DOCUMENTATION" in config files.
		/// </summary>
		public string BaseEndOfTypeDocumentation { get; }

		/// <summary>
		/// The string to describe <see cref="LocaleStrings"/> in config files.
		/// </summary>
		public string BaseLocaleStringsDescription { get; }

		/// <summary>
		/// The description of the <see cref="BaseModuleConfig.MinFallDamageSpeed"/> option.
		/// </summary>
		[ConfigLocalizedProperty]
		public string BaseConfigMinFallDamageSpeed { get; }

		/// <summary>
		/// The description of the <see cref="BaseModuleConfig.FallDamageDamping"/> option.
		/// </summary>
		[ConfigLocalizedProperty]
		public string BaseConfigFallDamageDamping { get; }

		#endregion

		#region Employment

		/// <summary>
		/// The message for when the employment module tries to give a weapon that does not exist.
		/// </summary>
		public string EmploymentWeaponDoesNotExist { get; }

		/// <summary>
		/// The description of the <see cref="EmploymentModuleConfig.SalaryPayPeriod"/> option.
		/// </summary>
		[ConfigLocalizedProperty]
		public string EmploymentConfigSalaryPayPeriod { get; }

		/// <summary>
		/// The description of the <see cref="EmploymentModuleConfig.DefaultWeapons"/> option.
		/// </summary>
		[ConfigLocalizedProperty]
		public string EmploymentConfigDefaultWeapons { get; }

		/// <summary>
		/// The description of the <see cref="EmploymentModuleConfig.Teams"/> option.
		/// </summary>
		[ConfigLocalizedProperty]
		public string EmploymentConfigTeams { get; }

		/// <summary>
		/// The description of the <see cref="TeamConfig.Category"/> option.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamConfigCategory { get; }

		/// <summary>
		/// The description of <see cref="TeamConfig.PrettyName"/> option.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamConfigPrettyName { get; }

		/// <summary>
		/// The description of the <see cref="TeamConfig.Description"/> option.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamConfigDescription { get; }

		/// <summary>
		/// The description of the <see cref="TeamConfig.Models"/> option.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamConfigModels { get; }

		/// <summary>
		/// The description of the <see cref="TeamConfig.Weapons"/> option.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamConfigWeapons { get; }

		/// <summary>
		/// The description of the <see cref="TeamConfig.ShouldGetDefaultWeapons"/> option.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamConfigShouldGetDefaultWeapons { get; }

		/// <summary>
		/// The description of the <see cref="TeamConfig.MaxPlayers"/> option.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamConfigMaxPlayers { get; }

		/// <summary>
		/// The description of the <see cref="TeamConfig.Salary"/> option.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamConfigSalary { get; }

		/// <summary>
		/// The description of the <see cref="TeamConfig.IsVoteRequired"/> option.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamConfigIsVoteRequired { get; }

		/// <summary>
		/// The description of the <see cref="TeamConfig.CanBeDemoted"/> option.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamConfigCanBeDemoted { get; }

		/// <summary>
		/// The description of the <see cref="TeamConfig.IsDefault"/> option.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamConfigIsDefault { get; }

		/// <summary>
		/// The description of the <see cref="TeamConfig.TeamType"/> option.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamConfigTeamType { get; }

		/// <summary>
		/// The locale string for the default value of the <see cref="TeamConfig.Category"/> option.
		/// </summary>
		[LocaleStringsProperty]
		public string TeamConfigStringDefaultCategory { get; }

		/// <summary>
		/// The locale string for the default value of the <see cref="TeamConfig.PrettyName"/> option.
		/// </summary>
		[LocaleStringsProperty]
		public string TeamConfigStringDefaultPrettyName { get; }

		/// <summary>
		/// The locale string for the default value of the <see cref="TeamConfig.Description"/> option.
		/// </summary>
		[LocaleStringsProperty]
		public string TeamConfigStringDefaultDescription { get; }

		#endregion

		#region Localization

		/// <summary>
		/// The description of the <see cref="LocalizationModuleConfig.Locale"/> option.
		/// </summary>
		[ConfigLocalizedProperty]
		public string LocalizationConfigLocale { get; }

		#endregion
	}
}
