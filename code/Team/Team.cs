using System.Collections.Generic;

namespace ChetoRp.Employment
{
	public class Team
	{
		public static Team DefaultTeam { get; } = new();
		private static readonly List<Team> teams = new();

		public int Id { get; }
		public string PrettyName { get; }

		private Team()
		{
		}

		public Team( string prettyName )
		{
			Id = teams.Count;
			PrettyName = prettyName;
			teams.Add( this );
		}
	}
}
