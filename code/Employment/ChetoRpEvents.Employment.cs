using ChetoRp.Employment;

namespace ChetoRp
{
	/// <summary>
	/// A static partial class containing constant event names.
	/// </summary>
	public static partial class ChetoRpEvents
	{
		/// <summary>
		/// The name of the event run before a team change.
		/// <para/>
		/// Event Parameters:<br/>
		/// <see cref="TeamChange"/> teamChange - Data about the team change.
		/// </summary>
		public const string PreTeamChange = "PreTeamChange";

		/// <summary>
		/// The name of the event run before a team change.
		/// <para/>
		/// Event Parameters:<br/>
		/// <see cref="TeamChange"/> teamChange - Data about the team change. <see cref="TeamChange.AllowTeamChange"/> has no effect because this event takes place after a team change.
		/// </summary>
		public const string PostTeamChange = "PostTeamChange";
	}
}
