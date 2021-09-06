using System;
using System.Threading;

namespace ChetoRp.Database
{
	public class DbTransaction : IDisposable
	{
		private static ulong transactionCounter = 0;
		private readonly static ThreadLocal<WeakReference<DbTransaction>> threadLocks;

		private ulong id;
		private ulong stepId;

		static DbTransaction()
		{
			threadLocks = new( () => new WeakReference<DbTransaction>( new DbTransaction() ) );

			// TODO: implement WAL rollbacks
		}

		public DbTransaction()
		{
			if ( threadLocks.Value.TryGetTarget( out _ ) )
			{
				throw new InvalidOperationException( $"A {nameof( DbTransaction )} is currently active on this thread. It must be disposed of." );
			}
			else
			{
				id = Interlocked.Increment( ref transactionCounter );
				threadLocks.Value.SetTarget( this );
			}
		}

		~DbTransaction()
		{
			Dispose(); // In case it was never called.
		}

		public DbTransaction CreateTable( string tableName, bool isBig = false )
		{
			// Log in WAL
			// if the table doesnt exist, create the folder as some in progress folder, create the big table file if necessary. if the table exists, do nothing
			// for secondary WAL: if table doesnt exist, create the folder and delete in progress folder. if it already exists, delete in progress folder if exists
			// to roll back, delete the in progress folder if it exists
			return this;
		}

		public DbTransaction DropTable( string tableName )
		{
			// Log in WAL
			// rename the folder, prefix with four underscores and ensure table names can't begin with four underscores
			// for secondary WAL:
			//		make a folder called ________deleted (8 underscores) if it doesn't exist
			//		move the folder prefixed with four underscores to this folder (prefix the four underscores with a random 64 bit number if it cant be moved to four underscores)
			//		create a dedicated thread to delete files and folders within this deleted folder which can be exeecuted using a static method during a secondary WAL action and on startup
			//		limit table names to 128 chars (enforced on creation and deletion of tbables only)
			//		
			// to roll back, rename the folder back
			return this;
		}

		public DbTransaction AddEntry<T>( string tableName, T entry, AddQueryType operationType = AddQueryType.InsertOrReplace )
		{
			// log in WAL
			// if insert and file isnt present, insert to in progress file, rename current entry file, rename in progress file to entry name if file present, throw exception, which will rollback if not caught.
			// if insertorreplace, insert to in progress file, rename current entry file, rename in progress file to entry name
			// if replace and file is present, insert to in progress file, rename current entry file, rename in progress to entry name if file present. if file not present, throw exception which will rollabck if not caught
			// for secondary WAL: delete old file if present
			// to roll back, if the entry file is still present in its renamed form, then rename any file called the entry file name and rename the renamed entry file back to the entry file name and delete other file. if not present, delete any renamed entry file names.
			return this;
		}

		public DbTransaction RemoveEntry<K>( string tableName, K key, RemoveQueryType operationType = RemoveQueryType.RemoveIfPresent )
		{
			// log in WAL
			// if remove, rename entry file if present, giving it a different extension. otherwise throw exception.
			// if removeifpresent, rename entry file if present, giving it a different extension. otherwise do nothing.
			// for secondary WAL: delete renamed entry file if present
			// to roll back, rename the rename entry file back if it's present
			return this;
		}

		public DbTransaction GetEntryOr<K, V>( string tableName, K key, Action<V, DbTransaction> entryAction ) // what to do if not exist
		{
			// Run the action with entry gotten as V and this, which will deal with the subtransaction
			return this;
		}

		public void Commit()
		{
			// Write secondary WAL, rename it, delete first WAL. Execute deletions as necessary. delete secondary WAL

			// rollbacks should only be done prior to the secondary WAL being renamed
			// if the secondary WAL is renamed, then roll forward (?

			// rename secondary WAL right before each step so that a restart would resume the secondary WAL at the right step.
			// queue deletion of ________deleted if it exists
		}
		public void Cancel()
		{
			// Rollback changes
		}

		public void Dispose()
		{
			// check primary WAL file. if it's still here. then rollback everything and log an error

			threadLocks.Value.SetTarget( null );
		}
	}
}
