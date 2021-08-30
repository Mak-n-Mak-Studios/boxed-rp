using System;

using ChetoRp.Employment;

using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The part of the <see cref="ChetoRpPlayer"/> class that deals with the Employment module.
	/// </summary>
	internal partial class ChetoRpPlayer : SandboxPlayer, IChetoRpPlayer
	{
		/// <summary>
		/// The team the player is on.
		/// </summary>
		[Net, Local]
		public Team Team { get; private set; } = Team.DefaultTeam;

		/// <summary>
		/// Sets the team of a player. Does nothing when called on the client.
		/// </summary>
		/// <returns>Whether the player's team could be set. Will return false if team switching failed.</returns>
		public bool SetTeam( Team newTeam )
		{
			// TO-DO: Return false if the max players is exceeded.

			TeamChange teamChange = new( this, Team, newTeam );
			Event.Run( ChetoRpEvents.PreTeamChange, teamChange );

			if ( !teamChange.AllowTeamChange )
			{
				return false;
			}

			Team = newTeam;
			SetModel( Team.Models[ new Random().Next( Team.Models.Length ) ] );
			Inventory.DeleteContents();

			foreach ( string weaponString in Team.Weapons )
			{
				BaseCarriable weapon = Library.Create<BaseCarriable>( weaponString );

				if ( weapon == null )
				{
					throw new ArgumentException( $"The provided team has a weapon that does not exist: \"{weaponString}\"." );
				}

				Inventory.Add( weapon );
			}

			Event.Run( ChetoRpEvents.PostTeamChange, teamChange );

			return true;
		}
	}
}
