using System;

using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The attribute to declare game modules.
	/// </summary>
	[AttributeUsage( AttributeTargets.Class, AllowMultiple = false )]
	public class GameModuleAttribute : LibraryAttribute
	{
		/// <summary>
		/// The default priority for modules.
		/// </summary>
		public const uint DefaultPriority = uint.MaxValue / 2;
		/// <summary>
		/// Gets the priority of the game module, which can be negative for special
		/// modules like the language module.
		/// </summary>
		public long Priority { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="GameModuleAttribute"/> class.
		/// </summary>
		/// <param name="priority">
		/// The priority to take into account when loading the module. Lower means higher priority.
		/// </param>
		public GameModuleAttribute( uint priority = DefaultPriority )
		{
			Priority = priority;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GameModuleAttribute"/> class.
		/// </summary>
		/// <param name="priority">
		/// The priority to take into account when loading the module. Lower means higher priority.
		/// </param>
		internal GameModuleAttribute( int priority )
		{
			Priority = priority;
		}
	}
}
