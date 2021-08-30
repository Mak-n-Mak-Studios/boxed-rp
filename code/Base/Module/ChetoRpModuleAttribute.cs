using System;

using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The attribute to declare ChetoRP modules.
	/// </summary>
	[AttributeUsage( AttributeTargets.Class, AllowMultiple = false )]
	public class ChetoRpModuleAttribute : LibraryAttribute { }
}
