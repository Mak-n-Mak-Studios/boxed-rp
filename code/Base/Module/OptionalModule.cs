namespace ChetoRp
{
	public abstract class OptionalModule<T> : Module<T> where T : IOptionalConfigStore, new()
	{
		public bool Enabled { get; }

		internal OptionalModule() : base()
		{
			// Set the Enabled property based on the config store's value.
		}

		internal override void PreRun()
		{
			// If module is enabled, run Run().
		}
	}
}
