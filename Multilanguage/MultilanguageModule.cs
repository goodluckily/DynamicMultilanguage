using System.Configuration;
using Microsoft.Extensions.Configuration;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.VirtualFileSystem;

namespace Multilanguage
{
    public class MultilanguageModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            
            Configure<AbpVirtualFileSystemOptions>(op =>
            {
                op.FileSets.AddEmbedded<MultilanguageModule>("Multilanguage", "Multilanguage");
            });


            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                     .Add<LangueResource>("zh-Hans")
                     //.Add<LangueResource>("en")
                    .AddVirtualJson("/Localization/Resources");
                options.DefaultResourceType = typeof(LangueResource);

                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
                options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁体中文"));
            });
            
            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Multilanguage", typeof(LangueResource));
            });
        }
    }
}
