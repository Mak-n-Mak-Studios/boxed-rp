using ChetoRp.Employment;

using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The main player class for ChetoRP.
	/// </summary>
	internal partial class ChetoRpPlayer : SandboxPlayer, IChetoRpPlayer
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
			Event.Run<IChetoRpPlayer>( "PrePlayerSpawn", this );
			base.Respawn();
			Event.Run<IChetoRpPlayer>( "PostPlayerSpawn", this );
		}

		/// <summary>
		/// Called every tick to simulate the player.
		/// </summary>
		public override void Simulate( Client client )
		{
			base.Simulate( client );
		}

		/// <summary>
		/// Called when the player takes damage.
		/// </summary>
		/// <param name="info">The damage info.</param>
		public override void TakeDamage( DamageInfo info )
		{
			ChetoRpDamageInfo modifiableDamageInfo = new();
			modifiableDamageInfo.DamageInfo = info;
			Event.Run( "PrePlayerTakeDamage", modifiableDamageInfo );
			base.TakeDamage( modifiableDamageInfo.DamageInfo );
			Event.Run( "PostPlayerTakeDamage", modifiableDamageInfo.DamageInfo );
		}

		/// <summary>
		/// Called when a player's health reaches 0.
		/// </summary>
		public override void OnKilled()
		{
			Event.Run<IChetoRpPlayer>( "PrePlayerDeath", this );
			base.OnKilled();
			Event.Run<IChetoRpPlayer>( "PostPlayerDeath", this );
		}
	}
}
