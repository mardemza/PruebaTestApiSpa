using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace PruebaApiSpa.Localization
{
    public static class PruebaApiSpaLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(PruebaApiSpaConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(PruebaApiSpaLocalizationConfigurer).GetAssembly(),
                        "PruebaApiSpa.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
