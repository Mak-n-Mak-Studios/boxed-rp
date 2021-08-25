using Sandbox;
using Sandbox.UI;

namespace ChetoRp
{
	/// <summary>
	/// The game class for ChetoRP.
	/// </summary>
	internal partial class ChetoRpGame : SandboxGame
	{
		/// <summary>
		/// Called on game load.
		/// </summary>
		public ChetoRpGame()
		{
			if ( IsServer )
			{
				Log.Info( "ChetoRP has started loading on the server..." );
			}

			if ( IsClient )
			{
				Log.Info( "ChetoRP has started loading on the client..." );
			}
		}

		/// <summary>
		/// Called when a client joins.
		/// </summary>
		public override void ClientJoined( Client client )
		{
			Log.Info( $"\"{client.Name}\" has joined the game" );
			ChatBox.AddInformation( To.Everyone, $"{client.Name} has joined", $"avatar:{client.SteamId}" );
			ChetoRpPlayer player = new();
			client.Pawn = player;
			player.Respawn();
		}

		/// <summary>
		/// Overwrites noclip.
		/// </summary>
		public override void DoPlayerNoclip( Client player )
		{
		}
	}
}
