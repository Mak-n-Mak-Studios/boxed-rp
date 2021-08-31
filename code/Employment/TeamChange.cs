namespace ChetoRp.Employment
{
	/// <summary>
	/// A class that holds data about team changes.
	/// </summary>
	public class TeamChange
	{
		/// <summary>
		/// The player that is changing teams.
		/// </summary>
		public IGamePlayer Player { get; }

		/// <summary>
		/// The team the player is switching from.
		/// </summary>
		public Team OldTeam { get; }

		/// <summary>
		/// The team the player is switching to.
		/// </summary>
		public Team NewTeam { get; }

		/// <summary>
		/// Whether the team change should be allowed to continue. Set to false to disallow the team change. Has no effect if changed in the <see cref="GameEvents.PostTeamChange"/> event.
		/// </summary>
		public bool AllowTeamChange { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="TeamChange"/> class.
		/// </summary>
		/// <param name="player">The player that is changing teams.</param>
		/// <param name="oldTeam">The team the player is switching from.</param>
		/// <param name="newTeam">The team the player is switching to.</param>
		public TeamChange( IGamePlayer player, Team oldTeam, Team newTeam )
		{
			Player = player;
			OldTeam = oldTeam;
			NewTeam = newTeam;
			AllowTeamChange = true;
		}
	}
}
