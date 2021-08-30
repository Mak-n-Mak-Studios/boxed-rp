using System;

namespace ChetoRp.Employment
{
	/// <summary>
	/// The class used to build teams.
	/// </summary>
	[ChetoRpConfigObject]
	public class TeamConfig
	{
		/// <summary>
		/// The category of the team.
		/// </summary>
		[ChetoRpConfigOptionInfo( "The category of the team." )]
		public string Category { get; set; } = "Uncategorized";

		/// <summary>
		/// The pretty name of the team.
		/// </summary>
		[ChetoRpConfigOptionInfo( "The pretty name of the team." )]
		public string PrettyName { get; set; } = "";

		/// <summary>
		/// The description of the team.
		/// </summary>
		[ChetoRpConfigOptionInfo( "The description of the team." )]
		public string Description { get; set; } = "";

		/// <summary>
		/// The possible models of the players in the team.
		/// </summary>
		[ChetoRpConfigOptionInfo( "The possible models of the players in the team." )]
		public string[] Models { get; set; } = Array.Empty<string>();

		/// <summary>
		/// The weapons given to players in the team on spawn.
		/// </summary>
		[ChetoRpConfigOptionInfo( "The weapons given to players in the team on spawn." )]
		public Weapon[] Weapons { get; set; } = Array.Empty<Weapon>();

		/// <summary>
		/// Whether the default weapons should be given to this team.
		/// </summary>
		[ChetoRpConfigOptionInfo( "Whether the default weapons should be given to this team." )]
		public bool ShouldGetDefaultWeapons { get; set; } = true;

		/// <summary>
		/// The max number of players that can be in this team at a time. 0 = unlimited players.
		/// </summary>
		[ChetoRpConfigOptionInfo( "The max number of players that can be in this team at a time. 0 = unlimited players." )]
		public uint MaxPlayers { get; set; } = 0;

		/// <summary>
		/// The salary given to the player every pay period.
		/// </summary>
		[ChetoRpConfigOptionInfo( "The salary given to the player every pay period." )]
		public ulong Salary { get; set; } = 100;

		/// <summary>
		/// Whether a player needs to be voted into the team.
		/// </summary>
		[ChetoRpConfigOptionInfo( "Whether a player needs to be voted into the team." )]
		public bool IsVoteRequired { get; set; } = false;

		/// <summary>
		/// Whether players in the team can be demoted out of the team.
		/// </summary>
		[ChetoRpConfigOptionInfo( "Whether players in the team can be demoted out of the team." )]
		public bool CanBeDemoted { get; set; } = true;

		/// <summary>
		/// Whether this team should be the default team given when a player joins. The first default team in the configuration file will be the default team.
		/// </summary>
		[ChetoRpConfigOptionInfo( "Whether this team should be the default team given when a player joins. The first default team in the configuration file will be the default team." )]
		public bool IsDefault { get; set; } = false;

		/// <summary>
		/// Converts the <see cref="TeamConfig"/> to a <see cref="Team"/>.
		/// </summary>
		/// <returns>The converted <see cref="Team"/>.</returns>
		internal Team ToTeam()
		{
			return new Team( this );
		}
	}
}
