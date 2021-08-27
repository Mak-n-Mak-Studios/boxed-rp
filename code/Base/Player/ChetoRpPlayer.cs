using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The main player class for ChetoRP.
	/// </summary>
	internal partial class ChetoRpPlayer : SandboxPlayer, IChetoRpPlayer
	{
		/// <summary>
		/// Called when a player respawns.
		/// </summary>
		public override void Respawn()
		{
			Event.Run<IChetoRpPlayer>( ChetoRpEvents.PrePlayerSpawn, this );
			base.Respawn();
			Controller = new ChetoRpWalkController();
			Event.Run<IChetoRpPlayer>( ChetoRpEvents.PostPlayerSpawn, this );
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
			Event.Run<IChetoRpPlayer, ChetoRpDamageInfo>( ChetoRpEvents.PrePlayerTakeDamage, this, modifiableDamageInfo );
			base.TakeDamage( modifiableDamageInfo.DamageInfo );
			Event.Run<IChetoRpPlayer, DamageInfo>( ChetoRpEvents.PostPlayerTakeDamage, this, modifiableDamageInfo.DamageInfo );
		}

		/// <summary>
		/// Called when a player's health reaches 0.
		/// </summary>
		public override void OnKilled()
		{
			Event.Run<IChetoRpPlayer>( ChetoRpEvents.PrePlayerDeath, this );
			base.OnKilled();
			Event.Run<IChetoRpPlayer>( ChetoRpEvents.PostPlayerDeath, this );
		}
	}
}
