using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The main player class for the game.
	/// </summary>
	internal partial class GamePlayer : SandboxPlayer, IGamePlayer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GamePlayer"/> class.
		/// </summary>
		/// <param name="client">The player client.</param>
		public GamePlayer( Client client ) : base( client )
		{
		}

		/// <summary>
		/// Called when a player respawns.
		/// </summary>
		public override void Respawn()
		{
			Event.Run<IGamePlayer>( GameEvents.PrePlayerSpawn, this );
			base.Respawn();
			TeamRespawn();
			Controller = new GameWalkController();
			Event.Run<IGamePlayer>( GameEvents.PostPlayerSpawn, this );
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
			ModifiableDamageInfo modifiableDamageInfo = new();
			modifiableDamageInfo.DamageInfo = info;
			Event.Run<IGamePlayer, ModifiableDamageInfo>( GameEvents.PrePlayerTakeDamage, this, modifiableDamageInfo );
			base.TakeDamage( modifiableDamageInfo.DamageInfo );
			Event.Run<IGamePlayer, DamageInfo>( GameEvents.PostPlayerTakeDamage, this, modifiableDamageInfo.DamageInfo );
		}

		/// <summary>
		/// Called when a player's health reaches 0.
		/// </summary>
		public override void OnKilled()
		{
			Event.Run<IGamePlayer>( GameEvents.PrePlayerDeath, this );
			base.OnKilled();
			Event.Run<IGamePlayer>( GameEvents.PostPlayerDeath, this );
		}
	}
}
