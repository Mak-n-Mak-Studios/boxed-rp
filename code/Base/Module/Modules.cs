using System;
using System.Collections.Generic;

namespace ChetoRp
{
	/// <summary>
	/// The class for modules without a generic parameter. Should only be used directly internally.
	/// </summary>
	public static class Modules
	{
		private readonly static Dictionary<Type, object> modules = new();

		/// <summary>
		/// Starts all modules.
		/// </summary>
		internal static void Start()
		{
			// Will instantiate all modules via the ChetoRpModule attribute and add them to the modules dictionary. The object in the modules dictionary is the module instance corresponding to the type key. Make sure to run the events: PreModuleInit and PostModuleInit.
		}

		/// <summary>
		/// Gets a module instance by type.
		/// </summary>
		/// <returns>The module.</returns>
		public static T Get<T>() where T : Module
		{
			// Get the module from the dictionary and cast to T.
			return default;
		}
	}
}
