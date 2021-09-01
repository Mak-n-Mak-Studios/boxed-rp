using System;

using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// A static partial class containing constant event names.
	/// </summary>
	public static partial class GameEvents
	{
		// Game events.

		/// <summary>
		/// The name of the event run before the game initializes.
		/// </summary>
		public const string PreGameInit = "PreGameInit";

		/// <summary>
		/// The name of the event run when the game shuts down.
		/// </summary>
		public const string OnGameShutdown = "OnGameShutdown";

		/// <summary>
		/// The name of the event run before a module initializes.
		/// <para/>
		/// Event Parameters:<br/>
		/// <see cref="Type"/> moduleType - The type of the module being initialized.
		/// </summary>
		public const string PreModuleInit = "PreModuleInit";

		/// <summary>
		/// The name of the event run after a module initializes.
		/// <para/>
		/// Event Parameters:<br/>
		/// <see cref="Module"/> module - The module that was initialized.
		/// </summary>
		public const string PostModuleInit = "PostModuleInit";

		/// <summary>
		/// The name of the event run after all modules initialize.
		/// </summary>
		public const string OnAllModulesInit = "OnAllModulesInit";

		// Player events.

		/// <summary>
		/// The name of the event run before a player spawns.
		/// <para/>
		/// Event Parameters:<br/>
		/// <see cref="IGamePlayer"/> player - The player that is about to spawn.
		/// </summary>
		public const string PrePlayerSpawn = "PrePlayerSpawn";

		/// <summary>
		/// The name of the event run after a player spawns.
		/// <para/>
		/// Event Parameters:<br/>
		/// <see cref="IGamePlayer"/> player - The player that spawned.
		/// </summary>
		public const string PostPlayerSpawn = "PostPlayerSpawn";

		/// <summary>
		/// The name of the event run before a player takes damage. This can be used to modify the damage a player takes.
		/// <para/>
		/// Event Parameters:<br/>
		/// <see cref="IGamePlayer"/> player - The player that is taking damage.<br/>
		/// <see cref="ModifiableDamageInfo"/> damageInfo - The <see cref="ModifiableDamageInfo"/> representing the damage the player is about to take. Use this to view or modify the damage the player takes.
		/// </summary>
		public const string PrePlayerTakeDamage = "PrePlayerTakeDamage";

		/// <summary>
		/// The name of the event run after a player takes damage. Do NOT use this to modify the damage a player takes. Any changes will not modify the damage the player takes. Use <see cref="PrePlayerTakeDamage"/> if you need to modify the damage a player takes.
		/// <para/>
		/// Event Parameters:<br/>
		/// <see cref="IGamePlayer"/> player - The player that has taken damage.<br/>
		/// <see cref="DamageInfo"/> damageInfo - The DamageInfo representing the damage the player has taken.
		/// </summary>
		public const string PostPlayerTakeDamage = "PostPlayerTakeDamage";

		/// <summary>
		/// The name of the event run before a player dies.
		/// <para/>
		/// Event Parameters:<br/>
		/// <see cref="IGamePlayer"/> player - The player that is about to die.
		/// </summary>
		public const string PrePlayerDeath = "PrePlayerDeath";

		/// <summary>
		/// The name of the event run after a player dies.
		/// <para/>
		/// Event Parameters:<br/>
		/// <see cref="IGamePlayer"/> player - The player that has died.
		/// </summary>
		public const string PostPlayerDeath = "PostPlayerDeath";

		/// <summary>
		/// The name of the event run prior to an update to a config file.
		/// This does not mean that any config options necessarily changed.
		/// <para/>
		/// Event Parameters:<br/>
		/// <see cref="Module{T}"/> module - The module before the config change.
		/// </summary>
		public const string PreConfigChange = "PreConfigChange";

		/// <summary>
		/// The name of the event run after an update to a config file.
		/// This does not mean that any config options necessarily changed.
		/// <para/>
		/// Event Parameters:<br/>
		/// <see cref="Module{T}"/> module - The module after the config change.
		/// </summary>
		public const string PostConfigChange = "PostConfigChange";
	}
}
