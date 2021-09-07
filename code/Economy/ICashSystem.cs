namespace ChetoRp.Economy
{
	public interface ICashSystem
	{
		public ulong GetCash( IGamePlayer player );
		public void ModifyCash( IGamePlayer player, ulong modifier );
		public void SetCash( IGamePlayer player, ulong amount );
	}
}
