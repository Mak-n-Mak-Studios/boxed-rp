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
			PrettyName = "";
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Team"/> class.
		/// </summary>
		/// <param name="prettyName">The pretty name of the team.</param>
		public Team( string prettyName )
		{
			PrettyName = prettyName;
		}
	}
}
