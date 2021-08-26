namespace ChetoRp
{
	public abstract class Module
	{
		internal Module()
		{
		}

		internal virtual void PreRun()
		{
			// Run Run().
		}

		protected internal abstract void Run();
	}

	public abstract partial class Module<T> : Module where T : new()
	{
		public T ConfigStore { get; }

		internal Module()
		{
			// Run the InitializeConfig method, returning a ConfigStore.
			// Set ConfigStore to the above return value.
			// Run the PreRun method.
		}
	}
}
