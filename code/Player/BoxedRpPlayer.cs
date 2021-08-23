using Sandbox;

namespace BoxedRp
{
	/// <summary>
	/// The player class for BoxedRP.
	/// </summary>
	partial class BoxedRpPlayer : Player
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
			SetModel( "models/citizen/citizen.vmdl" );
			Controller = new WalkController();
			Animator = new StandardPlayerAnimator();
			Camera = IsFirstPerson ? new FirstPersonCamera() : new ThirdPersonCamera();
			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;
			base.Respawn();
		}

		public override void Simulate( Client client )
		{
			base.Simulate( client );
			SimulateActiveChild( client, ActiveChild );
		}

		public override void OnKilled()
		{
			base.OnKilled();
			EnableDrawing = false;
		}
	}
}
