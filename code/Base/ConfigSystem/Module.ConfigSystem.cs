using Sandbox;

using System;

namespace ChetoRp
{
	/// <summary>
	/// The part of the <see cref="Module{T}"/> class which deals with the config system.
	/// </summary>
	public abstract partial class Module<T> where T : new()
	{
		/// <summary>
		/// The name of the folder holding the config files within the data folder.
		/// </summary>
		public const string ConfigFolderName = "cheto-rp-config";

		private string configFileName;
		private string configFilePath;

		/// <summary>
		/// Initializes the config store for the module with values from the config file or default values and returns it.
		/// </summary>
		/// <returns>The initialized config store.</returns>
		private void InitializeConfig()
		{
			configFileName = GetType().FullName + ".txt";
			configFilePath = ConfigFolderName + "/" + configFileName;

			FileSystem.Data.CreateDirectory( ConfigFolderName );

			BaseFileSystem configFiles = FileSystem.Data.CreateSubSystem( ConfigFolderName );

			ReadConfigStoreFromDisk();

			// Write regardless of whether the file exists or not to update any fields that are missing or get rid of outdated fields.
			WriteConfigStoreToDisk( configFilePath );

			configFiles.Watch( configFileName ).OnChangedFile += OnConfigFileModified;
		}

		/// <summary>
		/// Updates the config store for the module to reflect new changes, calling the PreConfigChange and PostConfigChange.
		/// </summary>
		/// <param name="fileName">The config file's name.</param>
		private void OnConfigFileModified( string fileName )
		{
			Event.Run( ChetoRpEvents.PreConfigChange, this );

			ReadConfigStoreFromDisk();

			Event.Run( ChetoRpEvents.PostConfigChange, this );
		}

		/// <summary>
		/// Writes the contents of the config file from the disk into the config store. Silently fails.
		/// </summary>

		private void ReadConfigStoreFromDisk()
		{
			try
			{
				ConfigStore = FileSystem.Data.ReadJson<T>( configFilePath );
			}
			catch ( Exception )
			{
				// Don't do anything if ReadJson fails.
			}
		}

		/// <summary>
		/// Writes the config store to the disk, overwriting its current contents if there are any.
		/// This will create a new config file if one is not found in the proper place.
		/// The default path for the config file will be data/cheto-rp-config/&lt;MODULE_NAME&gt;.json.
		/// </summary>
		private void WriteConfigStoreToDisk( string filePath )
		{
			JsonUtil.WritePrettyPrintedJson( ConfigStore, FileSystem.Data, filePath );
		}
	}
}
