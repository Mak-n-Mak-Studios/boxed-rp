namespace ChetoRp
{
	/// <summary>
	/// Abstract class for optional modules. Inherit from this class when creating a module that can be disabled.
	/// </summary>
	public abstract class OptionalModule<T> : Module<T> where T : IOptionalConfigStore, new()
	{
		/// <summary>
		/// Whether the module is enabled. Mirrors the value in the config store.
		/// </summary>
		public bool Enabled { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="OptionalModule{T}"/> class. For internal use only.
		/// </summary>
		internal OptionalModule() : base()
		{
			// Set the Enabled property based on the config store's value.
		}

		/// <summary>
		/// Runs the module allowing for preparations before running. For internal use only.
		/// </summary>
		internal override void PreRun()
		{
			// If module is enabled, run Run().
		}
	}
}
