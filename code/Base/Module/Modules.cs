using System;
using System.Collections.Generic;

namespace ChetoRp
{
	public static class Modules
	{
		private readonly static Dictionary<Type, object> modules = new();

		internal static void Start()
		{
			// Will instantiate all modules via the ChetoRpModule attribute and add them to the modules dictionary. The object in the modules dictionary is the module instance corresponding to the type key.
		}

		public static T Get<T>() where T : Module
		{
			// Get the module from the dictionary and cast to T.
			return default;
		}
	}
}
