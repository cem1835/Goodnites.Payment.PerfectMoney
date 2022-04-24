using Localization.Resources.AbpUi;
using Goodnites.Payment.PerfectMoney.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Goodnites.Payment.PerfectMoney
{
    [DependsOn(
        typeof(PerfectMoneyApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class PerfectMoneyHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(PerfectMoneyHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<PerfectMoneyResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
