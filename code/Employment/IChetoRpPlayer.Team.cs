using ChetoRp.Employment;

namespace ChetoRp
{
	/// <summary>
	/// The part of the <see cref="IChetoRpPlayer"/> interface that deals with the Team module.
	/// </summary>
	public partial interface IChetoRpPlayer
	{
		/// <summary>
		/// The team the player is on.
		/// </summary>
		public Team Team { get; }

		/// <summary>
		/// Sets the team of a player.
		/// </summary>
		/// <returns>Whether the player's team could be set. Will return false if team switching failed.</returns>
		public bool SetTeam( Team newTeam );
	}
}
