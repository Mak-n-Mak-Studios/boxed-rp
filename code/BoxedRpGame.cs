using Sandbox;
using Sandbox.UI;

namespace BoxedRp
{
	/// <summary>
	/// The game class for BoxedRP.
	/// </summary>
	internal partial class BoxedRpGame : SandboxGame
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
			Log.Info( $"\"{client.Name}\" has joined the game" );
			ChatBox.AddInformation( To.Everyone, $"{client.Name} has joined", $"avatar:{client.SteamId}" );
			BoxedRpPlayer player = new();
			client.Pawn = player;
			player.Respawn();
		}

		public override void DoPlayerNoclip( Client player )
		{
		}
	}
}
