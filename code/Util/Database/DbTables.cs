﻿
using Sandbox;

using System;
using System.Threading.Tasks;

namespace ChetoRp.Database
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
		/// The name of the big table marker file with a slash prepended to it.
		/// </summary>
		internal const string BigTableFileName = "/.is-big-table";

		/// <summary>
		/// The file system for the database.
		/// </summary>
		internal static BaseFileSystem Database { get; }

		/// <summary>
		/// Sets up <see cref="DbTables"/> for future operations.
		/// </summary>
		static DbTables()
		{
			FileSystem.Data.CreateDirectory( "database" );

			Database = FileSystem.Data.CreateSubSystem( "database" );
		}

		/// <summary>
		/// Creates a database table. 
		/// </summary>
		/// <param name="tableName">The database table's name.</param>
		/// <param name="isBig">Whether the table will be a big table. If the table could potentially have over 100,000 entries, this should be set to true.</param>
		/// <returns>Returns true if the table was created successfully. False if it already existed. This has the potential to erroneously return true
		/// because the check for whether the table exists or not and creating the table together is not atomic.</returns>
		public static bool Create( string tableName, bool isBig = false )
		{
			if ( Database.DirectoryExists( tableName ) )
			{
				return false;
			}

			Database.CreateDirectory( tableName );

			if ( isBig )
			{
				Database.OpenWrite( tableName + BigTableFileName );
			}

			return true;
		}

		/// <summary>
		/// Drops a database table. Be careful when dropping tables. If
		/// the table has 100s of thousands of entries, it could potentially take
		/// minutes to delete one. When dropping large tables, use <see cref="DropAsync(string)"/>
		/// </summary>
		/// <param name="tableName">The database table's name.</param>
		public static void Drop( string tableName )
		{
			if ( Database.DirectoryExists( tableName ) )
			{
				return;
			}

			Database.DeleteDirectory( tableName, true );
		}

		/// <summary>
		/// Asynchronously drops a database table. It is highly recommended to use this over
		/// <see cref="Drop(string)"/> because this operation could take a lot of time.
		/// </summary>
		/// <param name="tableName">The database table's name.</param>
		/// <returns>Returns a <see cref="Task"/>. If the database table exists, the <see cref="Task"/>
		/// is a handle to the task of the database being dropped. Otherwise, the <see cref="Task"/> does nothing.</returns>
		public static async Task DropAsync( string tableName )
		{
			await Task.Factory.StartNew( () => Drop( tableName ), TaskCreationOptions.LongRunning );
		}
	}
}
