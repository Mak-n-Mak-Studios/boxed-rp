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
		public Team Team { get; private set; }

		/// <summary>
		/// Handles team-specific respawn behavior.
		/// </summary>
		private void TeamRespawn()
		{
			if ( Team == null )
			{
				SetTeamInternal( Team.DefaultTeam, true );

				return;
			}

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
			return SetTeamInternal( newTeam, false ) != null;
		}

		/// <summary>
		/// Sets the team and optionally calls the necessary events depending on whether the player is joining or not.
		/// </summary>
		/// <param name="newTeam">The team the player is switching to.</param>
		/// <param name="isPlayerJoining">Whether the player is currently joining.</param>
		/// <returns>The team that the player was set to. Will be null if the team switch failed.</returns>
		private Team SetTeamInternal( Team newTeam, bool isPlayerJoining )
		{
			if ( newTeam.IsFull() )
			{
				return null;
			}

			TeamChange teamChange = new( this, Team, newTeam );

			if ( !isPlayerJoining )
			{
				Event.Run( GameEvents.PreTeamChange, teamChange );

				if ( !teamChange.AllowTeamChange )
				{
					return null;
				}
			}

			if ( Team != null )
			{
				Team.CurrentPlayerCount--;
			}

			Team = newTeam;
			Team.CurrentPlayerCount++;
			TeamRespawn();

			if ( !isPlayerJoining )
			{
				Event.Run( GameEvents.PostTeamChange, teamChange );
			}

			return Team;
		}
	}
}
