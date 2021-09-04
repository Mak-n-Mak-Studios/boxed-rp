using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using ChetoRp.Localization;

using Sandbox;

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
		public string[] DefaultWeapons { get; set; } = new string[]
		{
			Library.GetAttribute( typeof( GravGun ) ).Name,
			Library.GetAttribute( typeof( PhysGun ) ).Name,
			Library.GetAttribute( typeof( Tool ) ).Name,
			Library.GetAttribute( typeof( Flashlight ) ).Name,
		};

		/// <summary>
		/// The teams in the game. Do not use this directly. Use <see cref="EmploymentModule.Teams"/> instead.
		/// </summary>
		[GameConfigOptionInfo( "EmploymentConfigTeams" )]
		public TeamConfig[] Teams { get; set; } = new TeamConfig[]
		{
			new TeamConfig()
			{
				Category = new LocaleStrings( "EmploymentConfigStringCivilian" ),
				PrettyName = new LocaleStrings( "EmploymentConfigStringCivilian" ),
				Description = new LocaleStrings( "EmploymentConfigStringCivilianDescription" ),
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
				Category = new LocaleStrings( "EmploymentConfigStringLawEnforcement" ),
				PrettyName = new LocaleStrings( "EmploymentConfigStringPoliceOfficer" ),
				Description = new LocaleStrings( "EmploymentConfigStringPoliceOfficerDescription" ),
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
				TeamType = TeamType.Police
			},
			new TeamConfig()
			{
				Category = new LocaleStrings( "EmploymentConfigStringLawEnforcement" ),
				PrettyName = new LocaleStrings( "EmploymentConfigStringUndercoverPoliceOfficer" ),
				Description = new LocaleStrings( "EmploymentConfigStringUndercoverPoliceOfficerDescription" ),
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
				TeamType = TeamType.Police
			},
			new TeamConfig()
			{
				Category = new LocaleStrings( "EmploymentConfigStringLawEnforcement" ),
				PrettyName = new LocaleStrings( "EmploymentConfigStringSwatOfficer" ),
				Description = new LocaleStrings( "EmploymentConfigStringSwatOfficerDescription" ),
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
				TeamType = TeamType.Police
			},
			new TeamConfig()
			{
				Category = new LocaleStrings( "EmploymentConfigStringLawEnforcement" ),
				PrettyName = new LocaleStrings( "EmploymentConfigStringSwatCommander" ),
				Description = new LocaleStrings( "EmploymentConfigStringSwatCommanderDescription" ),
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
				TeamType = TeamType.Police
			},
			new TeamConfig()
			{
				Category = new LocaleStrings( "EmploymentConfigStringLawEnforcement" ),
				PrettyName = new LocaleStrings( "EmploymentConfigStringPoliceChief" ),
				Description = new LocaleStrings( "EmploymentConfigStringPoliceChiefDescription" ),
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
				TeamType = TeamType.Police
			},
			new TeamConfig()
			{
				Category = new LocaleStrings( "EmploymentConfigStringEmergencyMedicalServices" ),
				PrettyName = new LocaleStrings( "EmploymentConfigStringParamedic" ),
				Description = new LocaleStrings( "EmploymentConfigStringParamedicDescription" ),
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
				TeamType = TeamType.Ems
			},
			new TeamConfig()
			{
				Category = new LocaleStrings( "EmploymentConfigStringGovernor" ),
				PrettyName = new LocaleStrings( "EmploymentConfigStringGovernor" ),
				Description = new LocaleStrings( "EmploymentConfigStringGovernorDescription" ),
				Models = new string[]
				{
					// TO-DO: Set models.
					"models/citizen/citizen.vmdl"
				},
				MaxPlayers = 1,
				Salary = 350,
				IsVoteRequired = true,
				TeamType = TeamType.Governor
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
