using Sandbox;

namespace BoxedRp
{
	/// <summary>
	/// The game class for BoxedRP.
	/// </summary>
	public partial class BoxedRpGame : Game
	{
		/// <summary>
		/// Called on game load.
		/// </summary>
		public BoxedRpGame()
		{
			if ( IsServer )
			{
				Log.Info( "BoxedRP has started loading on the server..." );
			}

			if ( IsClient )
			{
				Log.Info( "BoxedRP has started loading on the client..." );
			}
		}

		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );
			BoxedRpPlayer player = new();
			client.Pawn = player;
			player.Respawn();
		}
	}
}
