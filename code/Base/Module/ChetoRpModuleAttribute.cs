using System;

using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// The attribute to declare ChetoRP modules.
	/// </summary>
	[AttributeUsage( AttributeTargets.Class )]
	public class ChetoRpModuleAttribute : LibraryAttribute { }
}
