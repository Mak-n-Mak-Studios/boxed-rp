using System;

using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The attribute to declare game modules.
	/// </summary>
	[AttributeUsage( AttributeTargets.Class, AllowMultiple = false )]
	public class GameModuleAttribute : LibraryAttribute { }
}
