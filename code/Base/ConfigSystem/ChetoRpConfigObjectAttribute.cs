using System;

using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// An attribute to apply to all config stores and all objects that can be used 
	/// within them with serializable properties. Internally, this is used to read
	/// properties with [<see cref="ChetoRpConfigOptionInfoAttribute"/>] on them.
	/// </summary>
	[AttributeUsage( AttributeTargets.Class )]
	public class ChetoRpConfigObjectAttribute : LibraryAttribute { }
}
