namespace ChetoRp
{
	/// <summary>
	/// The config store class for <see cref="BaseModule"/>.
	/// </summary>
	public class BaseModuleConfig
	{
		/// <summary>
		/// The minimum speed the player needs to be going down vertically to take damage.
		/// </summary>
		public float MinFallDamageSpeed { get; set; } = 500;

		/// <summary>
		/// The damping of the fall damage value. The formula for fall damage is FallSpeed / FallDamageDamping.
		/// </summary>
		public int FallDamageDamping { get; set; } = 20;
	}

	/// <summary>
	/// The <see cref="BaseModule"/> entrypoint class.
	/// </summary>
	[ChetoRpModule]
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
