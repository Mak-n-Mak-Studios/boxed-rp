using System;

namespace ChetoRp.Economy
{
	public class CashSystem : ICashSystem
	{
		public void SetCash( IGamePlayer player, ulong amount )
		{
			// do checked addition
		}

		public ulong GetCash( IGamePlayer player )
		{
			throw new NotImplementedException();
		}

		// Add an overload with an Action callback to run side-effect-less code for GetCash

		public void ModifyCash( IGamePlayer player, ulong modifier )
		{
			// do checked addition
		}


	}
}
