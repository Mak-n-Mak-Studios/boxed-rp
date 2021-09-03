using System.Linq;

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
		public string Category { get; }

		/// <summary>
		/// The pretty name of the team.
		/// </summary>
		public string PrettyName { get; }

		/// <summary>
		/// The description of the team.
		/// </summary>
		public string Description { get; }

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
		/// Whether this team is a special team.
		/// </summary>
		public SpecialTeam IsSpecialTeam { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Team"/> class based on a <see cref="TeamConfig"/>.
		/// </summary>
		/// <param name="teamConfig">The <see cref="TeamConfig"/>.</param>
		internal Team( TeamConfig teamConfig )
		{
			if ( DefaultTeam == null && IsDefault )
			{
				DefaultTeam = this;
				MaxPlayers = 0;
			}
			else
			{
				MaxPlayers = teamConfig.MaxPlayers;
			}

			Category = teamConfig.Category;
			PrettyName = teamConfig.PrettyName;
			Description = teamConfig.Description;
			Models = teamConfig.Models.ToArray();
			ShouldGetDefaultWeapons = teamConfig.ShouldGetDefaultWeapons;
			Salary = teamConfig.Salary;
			IsVoteRequired = teamConfig.IsVoteRequired;
			CanBeDemoted = teamConfig.CanBeDemoted;
			IsDefault = teamConfig.IsDefault;
			IsSpecialTeam = teamConfig.IsSpecialTeam;

			if ( ShouldGetDefaultWeapons )
			{
				Weapons = Modules.Get<EmploymentModule>().ConfigStore.DefaultWeapons.Concat( teamConfig.Weapons ).ToArray();
			}
			else
			{
				Weapons = teamConfig.Weapons.ToArray();
			}
		}
	}
}
