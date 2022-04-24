using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Goodnites.Payment.PerfectMoney.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Goodnites.Payment.PerfectMoney
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class PerfectMoneyDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<PerfectMoneyDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<PerfectMoneyResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/PerfectMoney");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("PerfectMoney", typeof(PerfectMoneyResource));
            });
        }
    }
}
