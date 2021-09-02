using Sandbox;

namespace ChetoRp.Localization
{
	/// <summary>
	/// Subclasses of this attribute should be put on properties within <see cref="ILocale"/> when they
	/// need to be retrieved by <see cref="LocalizationManager{T}"/>.
	/// </summary>
	public abstract class LocalizationDataPropertyAttribute : PropertyAttribute { }
}
