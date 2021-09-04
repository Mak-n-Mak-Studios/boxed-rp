using ChetoRp.Localization.Locales;

using System;

namespace ChetoRp
{
	/// <summary>
	/// A static class to deal with database table entries in the game database.
	/// All database table entries have their own unique identifier column.
	/// Database table entry classes must be marked with <see cref="DbEntryAttribute"/>
	/// and the unique identifier column property must be marked with <see cref="DbEntryIdAttribute"/>.
	/// All database table entries must have exactly 1 marked unique identifier column. If the entry is being
	/// put in a big table, the unique identifier column's type must be a <see cref="ulong"/> or an <see cref="IConvertible"/> 
	/// that can be converted to one using <see cref="Convert.ToUInt64(object)"/>. If it's a small table, the unique identifier
	/// can be of any type, but uniqueness is determined by <see cref="object.ToString"/>.
	/// </summary>
	public static class DbEntries
	{
		/// <summary>
		/// Initializes caches used internally for database entries.
		/// </summary>
		static DbEntries()
		{
			// Ensure that all DbEntryAttributes have exactly 1 DbIdColumnAttribute in it. Make a static list of all DbEntryAttributes. Make a dictionary linking Type to DbEntryAttributes.
		}

		/// <summary>
		/// Adds a database entry to the given database table. The default operation type provided by operationType in this method is 
		/// <see cref="AddQueryType.InsertOrReplace"/>, which means the entry provided will be inserted if one with its unique identifier
		/// doesn't exist already. <see cref="AddQueryType.Insert"/> will throw an <see cref="InvalidOperationException"/> if the entry 
		/// already exists and <see cref="AddQueryType.Replace"/> will throw an <see cref="InvalidOperationException"/> if the entry doesn't exist.
		/// </summary>
		/// <param name="table">The database table.</param>
		/// <param name="entry">The object containing the entry's data.</param>
		/// <param name="operationType">The operation type. See the method description for more information.</param>
		public static void Add<T>( string table, T entry, AddQueryType operationType = AddQueryType.InsertOrReplace )
		{
			// Creates a new or replaces an existing entry file based on its unique identifier. Whether it throws an exception is based on operationType. Make it clear that T must have an attribute and the unique identifier within it. Check if the type is in the dictionary. If not, look through the static list of DbEntryAttributes to link first compatible type found using the "is" keyword. If none is found, throw an exception. Use the retrieved DbEntryAttributes to get the unique identifier attribute within properties to get the value of it and use it.
		}

		/// <summary>
		/// Attempts to get a database entry using the given key as the unique identifier.
		/// </summary>
		/// <param name="table">The table.</param>
		/// <param name="key">The unique identifier.</param>
		/// <param name="val">The parameter to pass the found entry in to.</param>
		/// <returns>Whether or not an entry could be retrieved or not.</returns>
		public static bool TryGet<K, V>( string table, K key, out V val )
		{
			// Attempts to get an entry file based on its unique identifier key. Returns false if it couldn't be retrieved. If the table is a small table, turn the key into a string. If it's a big table and the key is not able to be converted to a ulong with Convert.ToUInt64, propagate the exception. Document cases where this happens (if K does not implement IConvertible or a conversion to a ulong is unsupported). If the file can't be found, throw an exception. If the object found can't be deserialized into V, then throw an exception
			throw new NotImplementedException();
		}

		/// <summary>
		/// Get a database entry using the given key as the unique identifier or falls back to the provided default.
		/// </summary>
		/// <param name="table">The table.</param>
		/// <param name="key">The unique identifier.</param>
		/// <param name="defaultValue">The entry object to default to if no entry is found.</param>
		/// <returns>The entry found or defaultValue if none was found.</returns>
		public static V GetOrElse<K, V>( string table, K key, V defaultValue )
		{
			// Do all of the above except if the file can't be found then use defaultValue.
			throw new NotImplementedException();
		}

		/// <summary>
		/// Removes an entry given its unique identifier. The default operation type is 
		/// <see cref="RemoveQueryType.RemoveIfPresent"/>. This will remove an entry if it's
		/// not present and do nothing if it doesn't exist. <see cref="RemoveQueryType.Remove"/>
		/// will throw an <see cref="InvalidOperationException"/> if no entry with the given identifier exist.
		/// </summary>
		/// <param name="table">The table.</param>
		/// <param name="key">The unique identifier.</param>
		/// <param name="operationType">The operation type. See the method description for more information.</param>
		/// <returns>Whether or not an entry was removed. This will always be true if operationType is 
		/// <see cref="RemoveQueryType.Remove"/>.</returns>
		public static bool Remove<K>( string table, K key, RemoveQueryType operationType = RemoveQueryType.RemoveIfPresent )
		{
			// Removes an entry based on its unique identifier. Unique identifiers will be resolved the same way it is for the get operations. By default, this will remove the entry if it's present and return whether or not anything was actually removed. However, if set to RemoveQueryType.Remove, it will throw an exception if the entry didn't exist.
			throw new NotImplementedException();
		}
	}
}
