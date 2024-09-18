using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace GuardianNotifyBackend.Localization
{
    public static class GuardianNotifyBackendLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(GuardianNotifyBackendConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(GuardianNotifyBackendLocalizationConfigurer).GetAssembly(),
                        "GuardianNotifyBackend.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
