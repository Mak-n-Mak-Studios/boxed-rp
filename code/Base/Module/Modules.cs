using System;
using System.Collections.Generic;
using System.Linq;

using ChetoRp.Localization;

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
			IEnumerable<Type> moduleTypes = Library.GetAll<Module>()
				.Where( type => Library.GetAttribute( type ) is GameModuleAttribute )
				.OrderBy( type => ( Library.GetAttribute( type ) as GameModuleAttribute ).Priority );

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
					Log.Error( e, string.Format( LocalizationModule.Locale?.BaseFailedToLoadModule ?? "Module of type, {0}, failed to load.", type.FullName ) );
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
