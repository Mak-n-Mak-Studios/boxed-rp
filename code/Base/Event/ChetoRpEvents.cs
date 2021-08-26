namespace ChetoRp
{
	/// <summary>
	/// A static class containing constant event names.
	/// </summary>
	public static class ChetoRpEvents
	{
		// Game events.

		/// <summary>
		/// The name of the event run before the game initializes.
		/// </summary>
		public const string PreGameInit = "PreGameInit";

		public const string PostGameInit = "PostGameInit";

		public const string OnGameShutdown = "OnGameShutdown";

		public const string PreModuleInit = "PreModuleInit";

		public const string PostModuleInit = "PostModuleInit";

		public const string OnAllModulesInit = "OnAllModulesInit";

		// Player events.

		public const string PrePlayerSpawn = "PrePlayerSpawn";

		public const string PostPlayerSpawn = "PostPlayerSpawn";

		public const string PrePlayerTakeDamage = "PrePlayerTakeDamage";

		public const string PostPlayerTakeDamage = "PostPlayerTakeDamage";

		public const string PrePlayerDeath = "PrePlayerDeath";

		public const string PostPlayerDeath = "PostPlayerDeath";

		/// <summary>
		/// The name of the event run prior to a config change.
		/// </summary>
		public const string PreConfigChange = "PreConfigChange";

		/// <summary>
		/// The name of the event run after a config change.
		/// </summary>
		public const string PostConfigChange = "PostConfigChange";
	}
}
