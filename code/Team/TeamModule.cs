using Sandbox;

namespace ChetoRp.Employment
{
	/// <summary>
	/// The config store class for <see cref="TeamModule"/>.
	/// </summary>
	public class TeamModuleConfig
	{
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
