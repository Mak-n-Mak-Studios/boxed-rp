using System;
using System.Collections.Generic;

using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The class that manages modules.
	/// </summary>
	public static class Modules
	{
		/// <summary>
		/// A dictionary of all loaded modules.
		/// </summary>
		internal static Dictionary<Type, Module> ModulesDictionary { get; } = new();

		/// <summary>
		/// Starts all modules.
		/// </summary>
		internal static void Start()
		{
			IEnumerable<Type> moduleTypes = Library.GetAll<Module>();

			foreach ( Type type in moduleTypes )
			{
				Event.Run( GameEvents.PreModuleInit, type );

				try
				{
					Module module = Library.Create<Module>( type );
					Event.Run( GameEvents.PostModuleInit, module );
				}
				catch ( Exception e )
				{
					Log.Error( e, $"Module of type, {type.FullName}, failed to load." );
				}
			}

			Event.Run( GameEvents.OnAllModulesInit );
		}

		/// <summary>
		/// Gets a module instance by type.
		/// </summary>
		/// <returns>The module.</returns>
		public static T Get<T>() where T : Module
		{
			return ( T ) ModulesDictionary[ typeof( T ) ];
		}
	}
}
