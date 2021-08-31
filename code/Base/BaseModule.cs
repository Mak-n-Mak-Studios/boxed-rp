namespace ChetoRp
{
	/// <summary>
	/// The config store class for <see cref="BaseModule"/>.
	/// </summary>
	[GameConfigObject]
	public class BaseModuleConfig
	{
		/// <summary>
		/// The minimum speed the player needs to be going down vertically to take damage.
		/// </summary>
		[GameConfigOptionInfo( "The minimum speed the player needs to be going down vertically to take damage." )]
		public float MinFallDamageSpeed { get; set; } = 500;

		/// <summary>
		/// The damping of the fall damage value. The formula for fall damage is FallSpeed / FallDamageDamping.
		/// </summary>
		[GameConfigOptionInfo( "The damping of the fall damage value. The formula for fall damage is FallSpeed / FallDamageDamping." )]
		public int FallDamageDamping { get; set; } = 20;
	}

	/// <summary>
	/// The <see cref="BaseModule"/> entrypoint class.
	/// </summary>
	[GameModule]
	public class BaseModule : Module<BaseModuleConfig>
	{
		/// <summary>
		/// The entrypoint to the module.
		/// </summary>
		protected internal override void Run()
		{
		}
	}
}
