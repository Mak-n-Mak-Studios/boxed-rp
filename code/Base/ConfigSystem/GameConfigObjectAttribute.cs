using System;

using Sandbox;

namespace ChetoRp
{
	/// <summary>
	/// An attribute to apply to all config stores and all objects that can be used 
	/// within them with serializable properties. Internally, this is used to read
	/// properties with [<see cref="GameConfigOptionInfoAttribute"/>] on them.
	/// <br/><br/><b>IMPORTANT</b>: Classes marked with this attribute must have
	/// a parameterless constructor because they will be instantiated
	/// every time the config file is rewritten.
	/// </summary>
	[AttributeUsage( AttributeTargets.Class, AllowMultiple = false )]
	public class GameConfigObjectAttribute : LibraryAttribute { }
}
