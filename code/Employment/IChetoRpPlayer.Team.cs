using ChetoRp.Employment;

namespace ChetoRp
{
	/// <summary>
	/// The part of the <see cref="IChetoRpPlayer"/> interface that deals with the Team module.
	/// </summary>
	public partial interface IChetoRpPlayer
	{
		/// <summary>
		/// The team the player is on.
		/// </summary>
		public Team Team { get; set; }
	}
}
