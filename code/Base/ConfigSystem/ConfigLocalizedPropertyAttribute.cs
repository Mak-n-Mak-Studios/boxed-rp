using System;

using ChetoRp.Localization;

namespace ChetoRp
{
	/// <summary>
	/// The attribute to put on properties within <see cref="ILocale"/> when
	/// they're localized config option descriptions. Name of the property should
	/// be "[ClassName][OptionName]".
	/// </summary>
	[AttributeUsage( AttributeTargets.Property, AllowMultiple = false )]
	public class ConfigLocalizedPropertyAttribute : LocalizationDataPropertyAttribute { }
}
