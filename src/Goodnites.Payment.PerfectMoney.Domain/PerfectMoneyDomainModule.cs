using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Goodnites.Payment.PerfectMoney
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(PerfectMoneyDomainSharedModule)
    )]
    public class PerfectMoneyDomainModule : AbpModule
    {

    }
}
