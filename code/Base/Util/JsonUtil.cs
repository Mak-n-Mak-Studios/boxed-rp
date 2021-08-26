using Sandbox;

using System.Text.Json;

namespace ChetoRp
{
	/// <summary>
	/// A static utility class for working with JSON data.
	/// </summary>
	public static class JsonUtil
	{
		private static readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions()
		{
			AllowTrailingCommas = true,
			ReadCommentHandling = JsonCommentHandling.Skip,
			WriteIndented = true
		};

		/// <summary>
		/// Writes the provided object as pretty printed JSON to the given file.
		/// </summary>
		/// <param name="obj">The object to write.</param>
		/// <param name="fileSystem">The file system containing the file to write to.</param>
		/// <param name="filePath">The file path relative to the given file system.</param>
		public static void WritePrettyPrintedJson<T>( T obj, BaseFileSystem fileSystem, string filePath )
		{
			string jsonData = JsonSerializer.Serialize( obj, serializerOptions );

			fileSystem.WriteAllText( filePath, jsonData );
		}
	}

}
