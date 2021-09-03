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
		/// The description of the <see cref="TeamConfig.IsSpecialTeam"/> option.
		/// </summary>
		[ConfigLocalizedProperty]
		public string TeamConfigIsSpecialTeam { get; }

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
