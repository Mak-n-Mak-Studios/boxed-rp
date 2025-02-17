﻿using ChetoRp.Employment;

namespace ChetoRp
{
	/// <summary>
	/// The part of the <see cref="IGamePlayer"/> interface that deals with the Team module.
	/// </summary>
	public partial interface IGamePlayer
	{
		/// <summary>
		/// The team the player is on.
		/// </summary>
		public Team Team { get; }

		/// <summary>
		/// Sets the team of a player.
		/// </summary>
		/// <param name="newTeam">The team the player is switching to.</param>
		/// <returns>Whether the player's team could be set. Will return false if team switching failed.</returns>
		public bool SetTeam( Team newTeam );
	}
}
