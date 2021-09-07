namespace ChetoRp
{
	/// <summary>
	/// The interface for the game player.
	/// </summary>
	public partial interface IGamePlayer
	{
		public ulong Cash { get; }
		public ulong BankBalance { get; }

		public void SetCash();

		public void ModifyCash();

		public void SetBankBalance();

		public void ModifyBankBalance();

		public void TransferToBank();

		public void TransferToCash();
	}
}
