using System;

using ChetoRp.Employment;
using ChetoRp.Localization;

using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The part of the <see cref="GamePlayer"/> class that deals with the Employment module.
	/// </summary>
	internal partial class GamePlayer : SandboxPlayer, IGamePlayer
	{
		/// <summary>
		/// The team the player is on.
		/// </summary>
		[Net, Local]
		public Team Team { get; private set; } = GetDefaultTeamAndIncrementPlayerCount();

		/// <summary>
		/// Gets the default team and increments its player count.
		/// </summary>
		/// <returns>The <see cref="Team.DefaultTeam"/>.</returns>
		private static Team GetDefaultTeamAndIncrementPlayerCount()
		{
			Team.DefaultTeam.CurrentPlayerCount++;

			return Team.DefaultTeam;
		}

		/// <summary>
		/// Handles team-specific respawn behavior.
		/// </summary>
		private void TeamRespawn()
		{
			SetModel( Team.Models[ new Random().Next( Team.Models.Length ) ] );
			Inventory.DeleteContents();

			foreach ( string weaponString in Team.Weapons )
			{
				BaseCarriable weapon = Library.Create<BaseCarriable>( weaponString );

				if ( weapon == null )
				{
					Log.Error( LocalizationModule.Locale.EmploymentWeaponDoesNotExist.Format( Team.PrettyName, weaponString ) );

					continue;
				}

				Inventory.Add( weapon );
			}
		}

		/// <summary>
		/// Sets the team of a player. Does nothing when called on the client.
		/// </summary>
		/// <param name="newTeam">The team the player is switching to.</param>
		/// <returns>Whether the player's team could be set. Will return false if team switching failed.</returns>
		public bool SetTeam( Team newTeam )
		{
			if ( newTeam.IsFull() )
			{
				return false;
			}

			TeamChange teamChange = new( this, Team, newTeam );
			Event.Run( GameEvents.PreTeamChange, teamChange );

			if ( !teamChange.AllowTeamChange )
			{
				return false;
			}

			Team.CurrentPlayerCount--;
			Team = newTeam;
			Team.CurrentPlayerCount++;
			TeamRespawn();
			Event.Run( GameEvents.PostTeamChange, teamChange );

			return true;
		}
	}
}
