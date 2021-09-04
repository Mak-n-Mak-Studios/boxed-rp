using Sandbox;

using System;

namespace ChetoRp
{
	/// <summary>
	/// A static class to deal with tables in the game database.
	/// Database tables are dynamic and aren't associated with any
	/// particular entry type. There are 2 types of tables: small tables
	/// and big tables. Big tables should be used when it could have
	/// over 100,000 entries. Once a table is made, its type cannot be changed.
	/// Big tables can only have entry types inserted into it where the unique identifier
	/// is a <see cref="ulong"/> or implements <see cref="IConvertible"/> and can be converted into a
	/// <see cref="ulong"/> using <see cref="Convert.ToUInt64(object)"/>. For small tables, the unique identifiers
	/// will be converted to strings using <see cref="object.ToString"/>.
	/// </summary>
	public static class DbTables
	{
		/// <summary>
		/// The <see cref="BaseFileSystem"/> the database resides in.
		/// </summary>
		public static BaseFileSystem Database { get; } = FileSystem.Data.CreateSubSystem( "database" );

		/// <summary>
		/// Creates a database table. 
		/// </summary>
		/// <param name="tableName">The database table's name.</param>
		/// <param name="isBig">Whether the table will be a big table. If the table could potentially have over 100,000 entries, this should be set to true.</param>
		/// <returns>Whether the table was successfully created or not.</returns>
		public static bool Create( string tableName, bool isBig = false )
		{
			// Create a subfolder within the database folder and a marker file if it's a big table.
			throw new NotImplementedException();
		}

		/// <summary>
		/// Drops a database table.
		/// </summary>
		/// <param name="tableName">The database table's name.</param>
		/// <returns>Whether the table was successfully dropped or not.</returns>
		public static bool Drop( string tableName )
		{
			// Delete a subfolder within the database folder
			throw new NotImplementedException();
		}
	}
}
