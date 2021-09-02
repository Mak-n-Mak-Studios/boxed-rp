using System.Collections.Generic;

using ChetoRp.Localization.Locales;

using Sandbox;

namespace ChetoRp.Localization
{
	/// <summary>
	/// The localization module's config.
	/// </summary>
	[GameConfigObject]
	public class LocalizationModuleConfig
	{
		/// <summary>
		/// The locale of the client/server.
		/// </summary>
		[GameConfigOptionInfo( "LocalizationConfigLocale" )]
		public LocaleType Locale { get; set; } = LocaleType.EnUs;
	}

	/// <summary>
	/// The module responsible for localization.
	/// </summary>
	[GameModule( -10000 )]
	public class LocalizationModule : Module<LocalizationModuleConfig>
	{
		private LocaleType oldLocale;
		private static LocalizationModule currentModule;

		/// <summary>
		/// The current locale to use for all localization purposes.
		/// This property will return null if the locale module has 
		/// not been initialized yet.
		/// </summary>
		public static ILocale Locale => currentModule?.CurrentLocale;

		/// <summary>
		/// The current locale to use for all localization purposes.
		/// </summary>
		public ILocale CurrentLocale { get; protected set; }

		/// <summary>
		/// A read-only dictionary containing mappings for locale types to their locale object.
		/// </summary>
		public IReadOnlyDictionary<LocaleType, ILocale> LocaleDictionary { get; private set; } // TO-DO: Change to ReadOnlyDictionary, pending whitelist approval. Issue #841.
		protected Dictionary<LocaleType, ILocale> localeDictionary;

		/// <summary>
		/// The entrypoint to the module.
		/// </summary>
		protected internal override void Run()
		{
			currentModule = this;
			localeDictionary = new();

			localeDictionary.Add( LocaleType.EnUs, new AmericanEnglish() );
			localeDictionary.Add( LocaleType.EsUy, new UruguayanSpanish() );

			LocaleDictionary = localeDictionary;
			CurrentLocale = localeDictionary[ ConfigStore.Locale ];
		}

		/// <summary>
		/// Stores the old locale prior to a localization config change.
		/// </summary>
		/// <param name="module">The module the change will occur in.</param>
		[Event( GameEvents.PreConfigChange )]
		protected virtual void StoreOldLocale( Module module )
		{
			if ( module is not Module<LocalizationModuleConfig> )
			{
				return;
			}

			oldLocale = ConfigStore.Locale;
		}

		/// <summary>
		/// Fires the OnLocaleChange event if the locale has changed.
		/// </summary>
		/// <param name="module">The module the change occurred in.</param>
		[Event( GameEvents.PostConfigChange )]
		protected virtual void OnLocaleChange( Module module )
		{
			if ( module is not Module<LocalizationModuleConfig> _ || oldLocale == ConfigStore.Locale )
			{
				return;
			}

			CurrentLocale = localeDictionary[ ConfigStore.Locale ];

			Event.Run( GameEvents.OnLocaleChange, oldLocale, ConfigStore.Locale );
		}
	}

}
