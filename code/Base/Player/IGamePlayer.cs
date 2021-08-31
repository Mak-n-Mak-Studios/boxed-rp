using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The interface for the game player.
	/// </summary>
	public partial interface IGamePlayer
	{
		/// <summary>
		/// The main camera for the player.
		/// </summary>
		public ICamera MainCamera { get; set; }

		/// <summary>
		/// Gets the active pawn controller for the player.
		/// </summary>
		public PawnController GetActiveController();

		/// <summary>
		/// Gets the active pawn animator for the player.
		/// </summary>
		public PawnAnimator GetActiveAnimator();
	}
}
