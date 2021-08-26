namespace ChetoRp
{
	/// <summary>
	/// The part of the <see cref="Module {T}"/> class which deals with the config system.
	/// </summary>
	public abstract partial class Module<T> : Module where T : new()
	{
		/// <summary>
		/// Initializes the config store for the module with default values and returns it.
		/// </summary>
		/// <returns>The initialized config store.</returns>
		private T InitializeConfig()
		{
			return default;
		}

		/// <summary>
		/// Updates the config store for the module to reflect new changes, calling the PreConfigChange and PostConfigChange.
		/// </summary>
		/// <param name="fileName">The config file's name.</param>
		private void OnConfigFileModified( string fileName )
		{
			// Call the PreConfigChange event then update the struct using ReadConfigStoreFromDisk if no subscribers cancel it. Call PostConfigChange afterwards.
		}

		/// <summary>
		/// Writes  the config file from the disk into the config store object.
		/// </summary>
		private void ReadConfigStoreFromDisk()
		{
			// Read the data folder's config file and mutate ConfigStore.
		}

		/// <summary>
		/// Writes the config store to the disk, overwriting its current contents if there are any.
		/// This will create a new config file if one is not found in the proper place.
		/// The default path for the config file will be data/cheto-rp-config/&lt;MODULE_NAME&gt;.json.
		/// </summary>
		private void WriteConfigStoreToDisk()
		{
			// Write the entirety of the config store into a file, overwriting the current contents.
		}
	}
}
