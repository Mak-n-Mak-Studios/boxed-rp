namespace ChetoRp
{
	/// <summary>
	/// The main player class for the game.
	/// </summary>
	internal partial class GamePlayer : SandboxPlayer, IGamePlayer
	{
		public ulong Cash { get; protected set; }
		public ulong BankBalance { get; protected set; }

		public void SetCash( ulong amount )
		{

		}

		public void ModifyCash( ulong modifier )
		{

		}

		public void SetBankBalance()
		{

		}

		public void ModifyBankBalance()
		{

		}

		public void TransferToBank()
		{

		}

		public void TransferToCash()
		{

		}
	}
}
