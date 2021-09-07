namespace ChetoRp.Economy
{
	[GameConfigObject]
	public class EconomyConfig
	{

	}

	public class EconomyModule : Module<EconomyConfig>
	{
		protected CashSystem CashSystem { get; } = new CashSystem();
		protected BankSystem BankSystem { get; } = new BankSystem();

		protected internal override void Run()
		{
			throw new System.NotImplementedException();
		}
	}
}
