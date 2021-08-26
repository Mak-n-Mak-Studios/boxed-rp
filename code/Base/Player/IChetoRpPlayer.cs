using ChetoRp.Employment;

using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The interface for the ChetoRP player.
	/// </summary>
	public interface IChetoRpPlayer
	{
		/// <summary>
		/// The team the player is on.
		/// </summary>
		public Team Team { get; set; }

		/// <summary>
		/// The amount of money a player has.
		/// </summary>
		public ulong Money { get; set; }

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
