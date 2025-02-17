﻿using Sandbox;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ChetoRp.Database
{
	/// <summary>
	/// A static class to deal with database table entries in the game database.
	/// All database table entries have their own unique identifier column.
	/// Database table entry classes must be marked with <see cref="DbEntryAttribute"/>
	/// and the unique identifier column property must be marked with <see cref="DbEntryIdAttribute"/>.
	/// All database table entries must have exactly 1 marked unique identifier column. If this requirement is not met, 
	/// the static constructor will fail. If the entry is being put in a big table, the unique identifier column's type must be 
	/// a <see cref="ulong"/> or an <see cref="IConvertible"/> that can be converted to one using <see cref="Convert.ToUInt64(object)"/>. 
	/// If it's a small table, the unique identifier can be of any type, but uniqueness is determined by <see cref="object.ToString"/>.
	/// </summary>
	public static class DbEntries
	{
		private static readonly List<DbEntryAttribute> entryAttributes;
		private static readonly Dictionary<Type, DbEntryAttribute> typeToEntryCache;

		/// <summary>
		/// Initializes caches used internally for database entries. This will throw an
		/// <see cref="InvalidOperationException"/> if the requirements of database entry classes
		/// are not met for every class marked with <see cref="DbEntryAttribute"/>.
		/// </summary>
		static DbEntries()
		{
			entryAttributes = Library.GetAttributes<DbEntryAttribute>().ToList();

			var badAttributes = entryAttributes.Where(
				entryAttribute => entryAttribute.Properties.Where(
					property => property is DbEntryIdAttribute
				).Count() != 1
			).Select( entryAttribute => entryAttribute.FullName );

			if ( badAttributes.Any() )
			{
				string badAttributeString = string.Join( ", ", badAttributes );

				throw new InvalidOperationException( $"All classes with the [DbEntry] attribute must have exactly one property inside with the [DbEntryId] attribute. The following DbEntry classes do not: {badAttributeString}." );
			}

			static bool EntryAttributeHasValidType( DbEntryAttribute entryAttribute )
			{
				try
				{
					return Type.GetType( entryAttribute.FullName ) != null;
				}
				catch ( Exception )
				{
					return false;
				}
			}

			typeToEntryCache = entryAttributes.Where( EntryAttributeHasValidType )
				.ToDictionary(
					entryAttribute => Type.GetType( entryAttribute.FullName ),
					entryAttribute => entryAttribute
				);
		}

		/// <summary>
		/// Resolves an entry's path based on it's unique identifier.
		/// </summary>
		/// <param name="key">The unique identifier.</param>
		/// <param name="table">The table name.</param>
		/// <returns>The path relative to the database.</returns>
		private static string ResolveEntryPath( object key, string table )
		{
			if ( key == null )
			{
				throw new ArgumentNullException( nameof( key ), "The provided unique identifier can't be null." );
			}

			if ( DbTables.Database.FileExists( table + DbTables.BigTableFileName ) ) // Is a big table
			{
				ulong identifierHash = ( 14695981039346656037L ^ Convert.ToUInt64( key ) ) * 1099511628211;
				string firstHashByte = ( identifierHash >> 56 ).ToString( "x" );

				return $"{table}/{firstHashByte}/{key}.txt";
			}
			else // Is a small table
			{
				return $"{table}/{key}.txt";
			}
		}

		/// <summary>
		/// Adds a database entry to the given database table. <br/> Note that the class of the entry provided must be in accordance to the specification
		/// described in <see cref="DbEntries"/>'s documentation header. <br/> The default operation type provided by operationType in this method is 
		/// <see cref="AddQueryType.InsertOrReplace"/>, which means the entry provided will be inserted if one with its unique identifier
		/// doesn't exist already. <br/><see cref="AddQueryType.Insert"/> will throw an <see cref="InvalidOperationException"/> if the entry 
		/// already exists and <see cref="AddQueryType.Replace"/> will throw an <see cref="InvalidOperationException"/> if the entry doesn't exist.<br/>
		/// Note that the check for file existence and the addition of the file together is not atomic.<br/>
		/// An <see cref="ArgumentException"/> will be thrown if the entry's type doesn't have the <see cref="DbEntryAttribute"/> on it.<br/>
		/// An <see cref="InvalidCastException"/> will be thrown if the table is a big table and the entry type's unique identifier isn't able to
		/// be converted to a <see cref="ulong"/>. <br/>If the entry can't be serialized into JSON, a <see cref="JsonException"/> will be thrown.
		/// </summary>
		/// <param name="table">The database table.</param>
		/// <param name="entry">The object containing the entry's data. The entry class used must be in accordance to the specification described in <see cref="DbEntries"/></param>
		/// <param name="operationType">The operation type. See the method description for more information.</param>
		public static void Add<T>( string table, T entry, AddQueryType operationType = AddQueryType.InsertOrReplace )
		{
			if ( !typeToEntryCache.TryGetValue( entry.GetType(), out DbEntryAttribute entryAttribute ) )
			{
				entryAttribute = entryAttributes.Find( entryAttribute => entryAttribute.FullName == entry.GetType().FullName ) ??
					throw new ArgumentException( $"The provided entry class, {entry.GetType()}, does not have {nameof( DbEntryAttribute )} on it.", nameof( entry ) );
			}

			object identifierPropertyValue = entryAttribute.Properties[ 0 ].GetValue<object>( entry );
			string entryPath = ResolveEntryPath( identifierPropertyValue, table );

			switch ( operationType )
			{
				case AddQueryType.InsertOrReplace:
					break;
				case AddQueryType.Replace:
					if ( !DbTables.Database.FileExists( entryPath ) )
					{
						throw new InvalidOperationException( $"The {nameof( operationType )} was set to {nameof( AddQueryType.Replace )} and the entry being added doesn't exist yet." );
					}

					break;
				case AddQueryType.Insert:
					if ( DbTables.Database.FileExists( entryPath ) )
					{
						throw new InvalidOperationException( $"The {nameof( operationType )} was set to {nameof( AddQueryType.Insert )} and the entry being added already exists." );
					}

					break;
				default:
					throw new ArgumentException( "Unknown enum encountered." );
			}

			DbTables.Database.WriteJson( entryPath, entry );
		}

		/// <summary>
		/// Attempts to get a database entry using the given key as the unique identifier.<br/>
		/// Gives an <see cref="ArgumentNullException"/> if the key is null.<br/>
		/// An <see cref="InvalidCastException"/> will be thrown if the table is a big table and the entry type's unique identifier isn't able to
		/// be converted to a <see cref="ulong"/>.<br/>
		/// A <see cref="JsonException"/> will be thrown if entry can't be deserialized into the given path.<br/>
		/// </summary>
		/// <param name="table">The table.</param>
		/// <param name="key">The unique identifier.</param>
		/// <param name="val">The parameter to pass the found entry in to.</param>
		/// <returns>Whether or not an entry could be retrieved or not.</returns>
		public static bool TryGet<K, V>( string table, K key, out V val )
		{
			string entryPath = ResolveEntryPath( key, table );

			try
			{
				val = DbTables.Database.ReadJson<V>( entryPath );

				return true;
			}
			catch ( System.IO.IOException )
			{
				val = default;

				return false;
			}
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
			if ( TryGet( table, key, out V val ) )
			{
				return val;
			}
			else
			{
				return defaultValue;
			}
		}

		/// <summary>
		/// Removes an entry given its unique identifier. The default operation type is 
		/// <see cref="RemoveQueryType.RemoveIfPresent"/>. This will remove an entry if it's
		/// not present and do nothing if it doesn't exist. <see cref="RemoveQueryType.Remove"/>
		/// will throw an <see cref="InvalidOperationException"/> if no entry with the given identifier exist.<br/>
		/// Note that the check for file existence and the removal of the file together is not atomic.
		/// </summary>
		/// <param name="table">The table.</param>
		/// <param name="key">The unique identifier.</param>
		/// <param name="operationType">The operation type. See the method description for more information.</param>
		/// <returns>Whether or not an entry was removed. This will always be true if operationType is 
		/// <see cref="RemoveQueryType.Remove"/>.</returns>
		public static bool Remove<K>( string table, K key, RemoveQueryType operationType = RemoveQueryType.RemoveIfPresent )
		{
			string entryPath = ResolveEntryPath( key, table );

			if ( !DbTables.Database.FileExists( entryPath ) )
			{
				return operationType switch
				{
					RemoveQueryType.RemoveIfPresent => false,
					RemoveQueryType.Remove => throw new InvalidOperationException( $"The {nameof( operationType )} was set to {nameof( RemoveQueryType.Remove )} and the entry being removed doesn't exist." ),
					_ => throw new ArgumentException( "Unknown enum encountered." ),
				};
			}

			DbTables.Database.DeleteFile( entryPath );

			return true;
		}
	}
}
