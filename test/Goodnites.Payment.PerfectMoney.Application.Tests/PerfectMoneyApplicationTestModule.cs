using Volo.Abp.Modularity;

namespace Goodnites.Payment.PerfectMoney
{
    [DependsOn(
        typeof(PerfectMoneyApplicationModule),
        typeof(PerfectMoneyDomainTestModule)
        )]
    public class PerfectMoneyApplicationTestModule : AbpModule
    {

    }
}
