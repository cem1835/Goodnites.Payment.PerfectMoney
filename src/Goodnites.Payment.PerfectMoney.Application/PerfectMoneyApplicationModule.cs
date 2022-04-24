using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Goodnites.Payment.PerfectMoney
{
    [DependsOn(
        typeof(PerfectMoneyDomainModule),
        typeof(PerfectMoneyApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class PerfectMoneyApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<PerfectMoneyApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<PerfectMoneyApplicationModule>(validate: true);
            });
        }
    }
}
