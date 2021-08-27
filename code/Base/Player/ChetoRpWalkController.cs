using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The default walk controller, modified to have fall damage.
	/// </summary>
	public class ChetoRpWalkController : WalkController
	{
		/// <summary>
		/// The minimum speed the player needs to be going down vertically to take damage.
		/// </summary>
		public float MinFallDamageSpeed { get; set; } = 500;

		/// <summary>
		/// The damping of the fall damage value. The formula for fall damage is FallSpeed / FallDamageDamping.
		/// </summary>
		public int FallDamageDamping { get; set; } = 20;

		/// <summary>
		/// Simulates the player's movements.
		/// </summary>
		public override void Simulate()
		{
			bool wasOnGround = GroundEntity != null;
			float fallSpeed = Velocity.z >= 0 ? 0 : -Velocity.z;
			base.Simulate();
			bool isOnGround = GroundEntity != null;

			if ( !wasOnGround && isOnGround && fallSpeed >= MinFallDamageSpeed )
			{
				DamageInfo damageInfo = new()
				{
					Attacker = Entity.FindByIndex( 0 ), // World.
					Damage = ( fallSpeed - MinFallDamageSpeed ) / FallDamageDamping,
					Flags = DamageFlags.Fall
				};

				Pawn.TakeDamage( damageInfo );
			}
		}
	}
}
