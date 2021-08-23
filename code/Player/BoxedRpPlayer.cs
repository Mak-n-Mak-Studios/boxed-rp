using Sandbox;

namespace BoxedRp
{
	/// <summary>
	/// The player class for BoxedRP.
	/// </summary>
	internal partial class BoxedRpPlayer : SandboxPlayer
	{
		public override void Respawn()
		{
			base.Respawn();
		}

		public override void Simulate( Client client )
		{
			base.Simulate( client );
		}

		public override void OnKilled()
		{
			base.OnKilled();
		}
	}
}
