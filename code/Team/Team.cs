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
		private static readonly List<Team> teams = new() { DefaultTeam };

		/// <summary>
		/// The ID of the team.
		/// </summary>
		[ChetoRpConfigOptionInfo( "The ID of the team." )]
		public int Id { get; }

		/// <summary>
		/// The pretty name of the team.
		/// </summary>
		[ChetoRpConfigOptionInfo( "The pretty name of the team." )]
		public string PrettyName { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Team"/> class.
		/// </summary>
		public Team()
		{
			Id = teams?.Count ?? 0;
			PrettyName = "";
			teams?.Add( this );
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Team"/> class.
		/// </summary>
		/// <param name="prettyName">The pretty name of the team.</param>
		public Team( string prettyName ) : this()
		{
			PrettyName = prettyName;
		}
	}
}
