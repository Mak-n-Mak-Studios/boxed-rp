using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ChetoRp.Employment
{
	/// <summary>
	/// The config store class for <see cref="EmploymentModule"/>.
	/// </summary>
	[ChetoRpConfigObject]
	public class EmploymentModuleConfig
	{
		/// <summary>
		/// The number of seconds between each salary pay period.
		/// </summary>
		[ChetoRpConfigOptionInfo( "The number of seconds between each salary pay period." )]
		public int SalaryPayPeriod { get; set; } = 300;

		/// <summary>
		/// The default weapons given to all players.
		/// </summary>
		[ChetoRpConfigOptionInfo( "The default weapons given to all players." )]
		public Weapon[] DefaultWeapons { get; set; } = Array.Empty<Weapon>();

		/// <summary>
		/// The teams in the game. Do not use this directly. Use <see cref="EmploymentModule.Teams"/> instead.
		/// </summary>
		[ChetoRpConfigOptionInfo( "The teams in the game." )]
		public TeamConfig[] Teams { get; set; }
	}

	/// <summary>
	/// The <see cref="EmploymentModule"/> entrypoint class.
	/// </summary>
	[ChetoRpModule]
	public class EmploymentModule : Module<EmploymentModuleConfig>
	{
		/// <summary>
		/// A read-only view of all teams registered with the game.
		/// </summary>
		public ReadOnlyCollection<Team> Teams { get; private set; }
		private List<Team> teams;

		/// <summary>
		/// The entrypoint to the module.
		/// </summary>
		protected internal override void Run()
		{
			teams = ConfigStore.Teams.Select( teamConfig => { return teamConfig.ToTeam(); } ).ToList();
			Teams = teams.AsReadOnly();
		}

		/// <summary>
		/// Creates a team and adds it to <see cref="Teams"/>.
		/// </summary>
		/// <param name="teamConfig">The team config used to create the team.</param>
		public void CreateTeam( TeamConfig teamConfig )
		{
			teams.Add( teamConfig.ToTeam() );
		}

		// TO-DO: Register an event callback to pay out salary.
	}
}
