using Sandbox;

using System.Collections.Generic;

namespace ChetoRp.Language
{
	/// <summary>
	/// The language module's config.
	/// </summary>
	[GameConfigObject]
	public class LanguageModuleConfig
	{
		[GameConfigOptionInfo( "The language to use. By changing this option on the server, configs are regenerated into this language but will not affect the clients' languages. The client can use the console command 'changelanguage'." )]
		public LanguageType Language { get; set; } = LanguageType.EnUs;
	}

	/// <summary>
	/// The module responsible for localization.
	/// </summary>
	[GameModule( -10000 )]
	public class LanguageModule : Module<LanguageModuleConfig>
	{
		private LanguageType oldLanguage;
		private static LanguageModule currentModule;

		/// <summary>
		/// The current locale to use for all localization purposes.
		/// This property will return null if the language module has 
		/// not been initialized yet.
		/// </summary>
		public static ILocale Locale => currentModule?.CurrentLocale;

		/// <summary>
		/// The current locale to use for all localization purposes.
		/// </summary>
		public ILocale CurrentLocale { get; protected set; }

		/// <summary>
		/// A read-only dictionary containing mappings for languages and their locale object.
		/// </summary>
		public IReadOnlyDictionary<LanguageType, ILocale> LanguageDictionary { get; private set; } // TO-DO: Change to ReadOnlyDictionary, pending whitelist approval. Issue #841.
		protected Dictionary<LanguageType, ILocale> languageDictionary;

		/// <summary>
		/// The entrypoint to the module.
		/// </summary>
		protected internal override void Run()
		{
			currentModule = this;
			languageDictionary = new();

			languageDictionary.Add( LanguageType.EnUs, new AmericanEnglish() );
			languageDictionary.Add( LanguageType.EsUy, new UruguayanSpanish() );

			LanguageDictionary = languageDictionary;
			CurrentLocale = languageDictionary[ ConfigStore.Language ];
		}

		/// <summary>
		/// Stores the old language prior to a language config change.
		/// </summary>
		/// <param name="module">The module the change will occur in.</param>
		[Event( GameEvents.PreConfigChange )]
		protected virtual void StoreOldLanguage( Module module )
		{
			if ( module is not Module<LanguageModuleConfig> _ )
			{
				return;
			}

			oldLanguage = ConfigStore.Language;
		}

		/// <summary>
		/// Fires the OnLanguageChange event if the language has changed.
		/// </summary>
		/// <param name="module">The module the change occurred in.</param>
		[Event( GameEvents.PostConfigChange )]
		protected virtual void OnLanguageChange( Module module )
		{
			if ( module is not Module<LanguageModuleConfig> _ || oldLanguage == ConfigStore.Language )
			{
				return;
			}

			CurrentLocale = languageDictionary[ ConfigStore.Language ];

			Event.Run( GameEvents.OnLanguageChange, oldLanguage, ConfigStore.Language );
		}
	}

}
