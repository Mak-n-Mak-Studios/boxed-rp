using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ChetoRp.Employment
{
	/// <summary>
	/// The config store class for <see cref="EmploymentModule"/>.
	/// </summary>
	[GameConfigObject]
	public class EmploymentModuleConfig
	{
		/// <summary>
		/// The number of seconds between each salary pay period.
		/// </summary>
		[GameConfigOptionInfo( "EmploymentConfigSalaryPayPeriod" )]
		public int SalaryPayPeriod { get; set; } = 300;

		/// <summary>
		/// The default weapons given to all players.
		/// </summary>
		[GameConfigOptionInfo( "EmploymentConfigDefaultWeapons" )]
		public string[] DefaultWeapons { get; set; } = Array.Empty<string>();

		/// <summary>
		/// The teams in the game. Do not use this directly. Use <see cref="EmploymentModule.Teams"/> instead.
		/// </summary>
		[GameConfigOptionInfo( "EmploymentConfigTeams" )]
		public TeamConfig[] Teams { get; set; } = new TeamConfig[]
		{
			new TeamConfig()
			{
				Category = "Civilian",
				PrettyName = "Civilian",
				Description = "You are free to do anything you want. Commit crimes, become a drug lord, or start a shop. The world is yours.",
				Models = new string[]
				{
					// TO-DO: Set models.
					"models/citizen/citizen.vmdl"
				},
				CanBeDemoted = false,
				IsDefault = true
			},
			new TeamConfig()
			{
				Category = "Law Enforcement",
				PrettyName = "Police Officer",
				Description = "Your job is to enforce laws that the Governor sets. You are the backbone of the police department.",
				Models = new string[]
				{
					// TO-DO: Set models.
					"models/citizen/citizen.vmdl"
				},
				Weapons = new string[]
				{
					"weapon_pistol",
					"weapon_shotgun"
				},
				MaxPlayers = 5,
				Salary = 200,
				IsVoteRequired = true,
				IsSpecialTeam = SpecialTeam.Police
			},
			new TeamConfig()
			{
				Category = "Law Enforcement",
				PrettyName = "Undercover Police Officer",
				Description = "Your job is to enforce laws that the Governor sets. You can use your cover to trick criminals and arrest them when they commit crimes.",
				Models = new string[]
				{
					// TO-DO: Set models.
					"models/citizen/citizen.vmdl"
				},
				Weapons = new string[]
				{
					"weapon_pistol"
				},
				MaxPlayers = 5,
				Salary = 225,
				IsVoteRequired = true,
				IsSpecialTeam = SpecialTeam.Police
			},
			new TeamConfig()
			{
				Category = "Law Enforcement",
				PrettyName = "S.W.A.T. Officer",
				Description = "Your job is to enforce laws that the Governor sets. You will be called in intense situations that require heavy firepower and/or smart tactics.",
				Models = new string[]
				{
					// TO-DO: Set models.
					"models/citizen/citizen.vmdl"
				},
				Weapons = new string[]
				{
					"weapon_pistol",
					"weapon_smg"
				},
				MaxPlayers = 5,
				Salary = 250,
				IsVoteRequired = true,
				IsSpecialTeam = SpecialTeam.Police
			},
			new TeamConfig()
			{
				Category = "Law Enforcement",
				PrettyName = "S.W.A.T. Commander",
				Description = "Your job is to enforce laws that the Governor sets. You will be called in intense situations that require heavy firepower and/or smart tactics. You are to lead the S.W.A.T. officers under your command.",
				Models = new string[]
				{
					// TO-DO: Set models.
					"models/citizen/citizen.vmdl"
				},
				Weapons = new string[]
				{
					"weapon_pistol",
					"weapon_shotgun",
					"weapon_smg"
				},
				MaxPlayers = 1,
				Salary = 300,
				IsVoteRequired = true,
				IsSpecialTeam = SpecialTeam.Police
			},
			new TeamConfig()
			{
				Category = "Law Enforcement",
				PrettyName = "Police Chief",
				Description = "Your job is to enforce laws that the Governor sets. You are to lead the police officers under your command.",
				Models = new string[]
				{
					// TO-DO: Set models.
					"models/citizen/citizen.vmdl"
				},
				Weapons = new string[]
				{
					"weapon_pistol",
					"weapon_shotgun",
					"weapon_smg"
				},
				MaxPlayers = 1,
				Salary = 300,
				IsVoteRequired = true,
				IsSpecialTeam = SpecialTeam.Police
			},
			new TeamConfig()
			{
				Category = "Emergency Medical Services",
				PrettyName = "Paramedic",
				Description = "Your job is to heal people. If someone becomes incapacitated or requires medical assistance, you are to make sure they stay alive and are healthy.",
				Models = new string[]
				{
					// TO-DO: Set models.
					"models/citizen/citizen.vmdl"
				},
				Weapons = new string[]
				{
					// TO-DO: Add healing kit and defibrillation system.
				},
				MaxPlayers = 5,
				Salary = 250,
				IsSpecialTeam = SpecialTeam.Ems
			},
			new TeamConfig()
			{
				Category = "Governor",
				PrettyName = "Governor",
				Description = "Your job is to lead the state. You will create laws and have ultimate power over law enforcement. Be careful though. If you are unpopular enough, you may be recalled.",
				Models = new string[]
				{
					// TO-DO: Set models.
					"models/citizen/citizen.vmdl"
				},
				MaxPlayers = 1,
				Salary = 350,
				IsVoteRequired = true,
				IsSpecialTeam = SpecialTeam.Governor
			},
		};
	}

	/// <summary>
	/// The <see cref="EmploymentModule"/> entrypoint class.
	/// </summary>
	[GameModule]
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
