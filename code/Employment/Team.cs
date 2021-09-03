using System.Linq;

using ChetoRp.Localization;

namespace ChetoRp.Employment
{
	/// <summary>
	/// The class for teams.
	/// </summary>
	public class Team
	{
		/// <summary>
		/// The default team that players get when they connect.
		/// </summary>
		public static Team DefaultTeam { get; private set; }

		/// <summary>
		/// The category of the team.
		/// </summary>
		public LocaleStrings Category { get; }

		/// <summary>
		/// The pretty name of the team.
		/// </summary>
		public LocaleStrings PrettyName { get; }

		/// <summary>
		/// The description of the team.
		/// </summary>
		public LocaleStrings Description { get; }

		/// <summary>
		/// The possible models of the players in the team.
		/// </summary>
		public string[] Models { get; }

		/// <summary>
		/// The weapons given to players in the team on spawn.
		/// </summary>
		public string[] Weapons { get; }

		/// <summary>
		/// Whether the default weapons should be given to this team.
		/// </summary>
		public bool ShouldGetDefaultWeapons { get; }

		/// <summary>
		/// The max number of players that can be in this team at a time. 0 = unlimited players.
		/// </summary>
		public uint MaxPlayers { get; }

		/// <summary>
		/// The salary given to the player every pay period.
		/// </summary>
		public ulong Salary { get; }

		/// <summary>
		/// Whether a player needs to be voted into the team.
		/// </summary>
		public bool IsVoteRequired { get; }

		/// <summary>
		/// Whether players in the team can be demoted out of the team.
		/// </summary>
		public bool CanBeDemoted { get; }

		/// <summary>
		/// Whether this team should be the default team given when a player joins. The first default team in the configuration file will be the default team.
		/// </summary>
		public bool IsDefault { get; }

		/// <summary>
		/// The type of team.
		/// </summary>
		public TeamType TeamType { get; }

		/// <summary>
		/// The number of people currently in the team.
		/// </summary>
		public int CurrentPlayerCount { get; internal set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Team"/> class based on a <see cref="TeamConfig"/>.
		/// </summary>
		/// <param name="teamConfig">The <see cref="TeamConfig"/>.</param>
		internal Team( TeamConfig teamConfig )
		{
			Category = teamConfig.Category;
			PrettyName = teamConfig.PrettyName;
			Description = teamConfig.Description;
			Models = teamConfig.Models.ToArray();
			ShouldGetDefaultWeapons = teamConfig.ShouldGetDefaultWeapons;
			Salary = teamConfig.Salary;
			IsVoteRequired = teamConfig.IsVoteRequired;
			CanBeDemoted = teamConfig.CanBeDemoted;
			IsDefault = teamConfig.IsDefault;
			TeamType = teamConfig.TeamType;
			CurrentPlayerCount = 0;

			if ( DefaultTeam == null && IsDefault )
			{
				DefaultTeam = this;
				MaxPlayers = 0;
			}
			else
			{
				MaxPlayers = teamConfig.MaxPlayers;
			}

			if ( ShouldGetDefaultWeapons )
			{
				Weapons = Modules.Get<EmploymentModule>().ConfigStore.DefaultWeapons.Concat( teamConfig.Weapons ).ToArray();
			}
			else
			{
				Weapons = teamConfig.Weapons.ToArray();
			}
		}

		/// <summary>
		/// Checks whether the team's max players has been reached.
		/// </summary>
		/// <returns>Whether the team's max players has been reached.</returns>
		public bool IsFull()
		{
			return MaxPlayers != 0 && CurrentPlayerCount == MaxPlayers;
		}
	}
}
