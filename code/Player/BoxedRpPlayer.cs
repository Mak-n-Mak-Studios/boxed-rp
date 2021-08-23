using Sandbox;

namespace BoxedRp
{
	/// <summary>
	/// The player class for BoxedRP.
	/// </summary>
	internal partial class BoxedRpPlayer : SandboxPlayer
	{
		private bool isFirstPerson = true;

		public bool IsFirstPerson
		{
			get { return isFirstPerson; }
			set
			{
				isFirstPerson = value;
				Camera = IsFirstPerson ? new FirstPersonCamera() : new ThirdPersonCamera();
			}
		}

		/// <summary>
		/// Handles player spawning.
		/// </summary>
		public override void Respawn()
		{
			base.Respawn();
			Camera = IsFirstPerson ? new FirstPersonCamera() : new ThirdPersonCamera();
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
