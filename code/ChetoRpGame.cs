using Sandbox;
using Sandbox.UI;

namespace ChetoRp
{
	/// <summary>
	/// The main game class.
	/// </summary>
	internal partial class ChetoRpGame : SandboxGame
	{
		/// <summary>
		/// Called on game load.
		/// </summary>
		public ChetoRpGame() : base()
		{
			Event.Run( GameEvents.PreGameInit );
			Modules.Start();
			Log.Info( "ChetoRP has finished loading." );
		}

		/// <summary>
		/// Called when a client joins.
		/// </summary>
		public override void ClientJoined( Client client )
		{
			Log.Info( $"\"{client.Name}\" has joined the game" );
			ChatBox.AddInformation( To.Everyone, $"{client.Name} has joined", $"avatar:{client.SteamId}" );
			GamePlayer player = new();
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
			Event.Run( GameEvents.OnGameShutdown );
			base.Shutdown();
		}
	}
}
