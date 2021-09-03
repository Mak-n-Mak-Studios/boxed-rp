namespace ChetoRp
{
	/// <summary>
	/// A static class containing extension methods for <see cref="string"/>s.
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// A convenience instance method for string.Format.
		/// </summary>
		/// <param name="str">The format string.</param>
		/// <param name="arg">The object to format.</param>
		/// <returns>The formatted string.</returns>
		public static string Format( this string str, object arg )
		{
			return string.Format( str, arg );
		}

		/// <summary>
		/// A convenience instance method for string.Format.
		/// </summary>
		/// <param name="str">The format string.</param>
		/// <param name="arg">The objects to format.</param>
		/// <returns>The formatted string.</returns>
		public static string Format( this string str, params object[] arg )
		{
			return string.Format( str, arg );
		}
	}
}
