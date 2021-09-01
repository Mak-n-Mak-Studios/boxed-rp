
using Sandbox;

using System.Collections.Generic;
using System.Collections.ObjectModel;

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
	[GameModule]
	public class LanguageModule : Module<LanguageModuleConfig>
	{
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
		public ReadOnlyDictionary<LanguageType, ILocale> LanguageDictionary { get; private set; }
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

			LanguageDictionary = new( languageDictionary );
			CurrentLocale = languageDictionary[ ConfigStore.Language ];
		}

		/// <summary>
		/// Fires the PreLanguageChange event prior to a config change that
		/// changes the language of the game.
		/// </summary>
		/// <param name="module">The module the change will occur in.</param>
		[Event( GameEvents.PreConfigChange )]
		protected virtual void PreConfigChange( Module module )
		{
			if ( module is not Module<LanguageModuleConfig> mod )
			{
				return;
			}

			Event.Run( GameEvents.PreLanguageChange, mod.ConfigStore.Language );
		}

		/// <summary>
		/// Fires the PostLanguageChange event after a config change that
		/// changes the language of the game.
		/// </summary>
		/// <param name="module">The module the change occurred in.</param>
		[Event( GameEvents.PostConfigChange )]
		protected virtual void PostConfigChange( Module module )
		{
			if ( module is not Module<LanguageModuleConfig> mod )
			{
				return;
			}

			CurrentLocale = languageDictionary[ ConfigStore.Language ];

			Event.Run( GameEvents.PostLanguageChange, mod.ConfigStore.Language );
		}
	}

}
