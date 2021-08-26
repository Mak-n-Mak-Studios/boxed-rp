using System;
using System.Collections.Generic;

using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The class for modules without a generic parameter. Should only be used directly internally.
	/// </summary>
	public static class Modules
	{
		private readonly static Dictionary<Type, Module> modules = new();

		/// <summary>
		/// Starts all modules.
		/// </summary>
		internal static void Start()
		{
			IEnumerable<Type> moduleTypes = Library.GetAll<Module>();

			foreach ( Type type in moduleTypes )
			{
				Event.Run( ChetoRpEvents.PreModuleInit, type );

				try
				{
					Module module = Library.Create<Module>( type );
					modules.Add( type, module );
					Event.Run( ChetoRpEvents.PostModuleInit, module );
				}
				catch ( Exception e )
				{
					Log.Error( e, $"Module of type, { type.FullName }, failed to load." );
				}
			}

			Event.Run( ChetoRpEvents.OnAllModulesInit );
		}

		/// <summary>
		/// Gets a module instance by type.
		/// </summary>
		/// <returns>The module.</returns>
		public static T Get<T>() where T : Module
		{
			return ( T ) modules[ typeof( T ) ];
		}
	}
}
