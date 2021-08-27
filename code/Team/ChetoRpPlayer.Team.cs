using ChetoRp.Employment;

using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The part of the <see cref="ChetoRpPlayer"/> class that deals with the Team module.
	/// </summary>
	internal partial class ChetoRpPlayer : SandboxPlayer, IChetoRpPlayer
	{
		/// <summary>
		/// The team the player is on.
		/// </summary>
		[Net, Local]
		public Team Team { get; set; } = Team.DefaultTeam;
	}
}
