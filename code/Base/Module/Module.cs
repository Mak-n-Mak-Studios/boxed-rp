namespace ChetoRp
{
	/// <summary>
	/// Abstract class for modules. For internal use only. Extend <see cref="Module{T}"/> instead.
	/// </summary>
	public abstract class Module
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Module"/> class. For internal use only.
		/// </summary>
		internal Module()
		{
		}

		/// <summary>
		/// Runs the module allowing for preparations before running. For internal use only.
		/// </summary>
		internal virtual void PreRun()
		{
			Run();
		}

		/// <summary>
		/// The entrypoint to the module.
		/// </summary>
		protected internal abstract void Run();
	}

	/// <summary>
	/// Abstract class for modules. Inherit from this class when creating a module that cannot be disabled.
	/// </summary>
	public abstract partial class Module<T> : Module where T : new()
	{
		/// <summary>
		/// The config store for the module.
		/// </summary>
		public T ConfigStore { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Module{T}"/> class. For internal use only.
		/// </summary>
		internal Module() : base()
		{
			ConfigStore = InitializeConfig();
			PreRun();
		}
	}
}
