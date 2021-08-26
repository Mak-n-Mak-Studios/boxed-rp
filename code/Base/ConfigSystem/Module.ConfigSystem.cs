using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The part of the <see cref="Module {T}"/> class which deals with the config system.
	/// </summary>
	public abstract partial class Module<T> : Module where T : new()
	{
		/// <summary>
		/// The name of the folder holding the config files within the data folder.
		/// </summary>
		private const string CONFIG_FOLDER_NAME = "cheto-rp-config";

		/// <summary>
		/// Initializes the config store for the module with values from the config file or default values and returns it.
		/// </summary>
		/// <returns>The initialized config store.</returns>
		private T InitializeConfig()
		{
			T configStore = new();

			FileSystem.Data.CreateDirectory( CONFIG_FOLDER_NAME );

			BaseFileSystem configFiles = FileSystem.Data.CreateSubSystem( CONFIG_FOLDER_NAME );
			string configFileName = this.GetType().FullName + ".txt";

			if ( configFiles.FileExists( configFileName ) )
			{
				ReadConfigStoreFromDisk();
			}

			// Write regardless of whether the file exists or not to update any fields that are missing or get rid of outdated fields.
			WriteConfigStoreToDisk( CONFIG_FOLDER_NAME + "/" + configFileName );

			configFiles.Watch( configFileName ).OnChangedFile += OnConfigFileModified;

			return configStore;
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
		/// <param name="filePath">The path of the config file to write to.</param>
		/// </summary>
		private void WriteConfigStoreToDisk( string filePath )
		{
			// Write the entirety of the config store into a file, overwriting the current contents.
		}
	}
}
