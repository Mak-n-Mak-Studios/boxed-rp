using System.Collections.Generic;

namespace ChetoRp.Employment
{
	/// <summary>
	/// The class for teams.
	/// </summary>
	[ChetoRpConfigObject]
	public class Team
	{
		/// <summary>
		/// The default team.
		/// </summary>
		public static Team DefaultTeam { get; } = new();
		private static readonly List<Team> teams = new();

		/// <summary>
		/// The ID of the team.
		/// </summary>
		public int Id { get; }

		/// <summary>
		/// The pretty name of the team.
		/// </summary>
		public string PrettyName { get; }

		/// <summary>
		/// Prevents a default instance of the <see cref="Team"/> class from being created outside of the class.
		/// </summary>
		private Team()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Team"/> class.
		/// </summary>
		/// <param name="prettyName">The pretty name of the team.</param>
		public Team( string prettyName )
		{
			Id = teams.Count;
			PrettyName = prettyName;
			teams.Add( this );
		}
	}
}
