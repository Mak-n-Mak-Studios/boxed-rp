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
		public ChetoRpGame() : base()
		{
			Event.Run( ChetoRpEvents.PreGameInit );
			Log.Info( "ChetoRP has started loading..." );
			Event.Run( ChetoRpEvents.PostGameInit );
			Modules.Start();
			Log.Info( "ChetoRP and ChetoRP modules have finished loading." );
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

		/// <summary>
		/// Called on game shutdown.
		/// </summary>
		public override void Shutdown()
		{
			Event.Run( ChetoRpEvents.OnGameShutdown );
			base.Shutdown();
		}
	}
}
