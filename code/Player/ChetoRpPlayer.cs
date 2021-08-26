using ChetoRp.Employment;

using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The player class for ChetoRP.
	/// </summary>
	internal partial class ChetoRpPlayer : SandboxPlayer
	{
		/// <summary>
		/// The team the player is on.
		/// </summary>
		public Team Team { get; set; } = Team.DefaultTeam;

		/// <summary>
		/// The amount of money a player has.
		/// </summary>
		public ulong Money { get; set; } = 0;

		/// <summary>
		/// Called when a player respawns.
		/// </summary>
		public override void Respawn()
		{
			base.Respawn();
		}

		/// <summary>
		/// Called every tick to simulate the player.
		/// </summary>
		public override void Simulate( Client client )
		{
			base.Simulate( client );
		}

		/// <summary>
		/// Called when a player's health reaches 0.
		/// </summary>
		public override void OnKilled()
		{
			base.OnKilled();
		}
	}
}
