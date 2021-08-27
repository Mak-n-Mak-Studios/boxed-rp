using Sandbox;

namespace ChetoRp.Employment
{
	/// <summary>
	/// The config store class for <see cref="TeamModule"/>.
	/// </summary>
	[ChetoRpConfigObject]
	public class TeamModuleConfig
	{
		/// <summary>
		/// The teams in the game.
		/// </summary>
		[ChetoRpConfigOptionInfo( "The teams in the game." )]
		public Team[] Teams { get; set; } = new Team[] { new Team( "Test" ) };
	}

	/// <summary>
	/// The <see cref="TeamModule"/> entrypoint class.
	/// </summary>
	[ChetoRpModule]
	public class TeamModule : Module<TeamModuleConfig>
	{
		/// <summary>
		/// The entrypoint to the module.
		/// </summary>
		protected internal override void Run()
		{
			Log.Info( "Initialized the team module." );
		}
	}
}
