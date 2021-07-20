using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ControleVendas.Localization
{
    public static class ControleVendasLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ControleVendasConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ControleVendasLocalizationConfigurer).GetAssembly(),
                        "ControleVendas.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
