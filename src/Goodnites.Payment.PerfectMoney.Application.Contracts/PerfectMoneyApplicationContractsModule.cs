using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Goodnites.Payment.PerfectMoney
{
    [DependsOn(
        typeof(PerfectMoneyDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class PerfectMoneyApplicationContractsModule : AbpModule
    {

    }
}
