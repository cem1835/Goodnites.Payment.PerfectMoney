using Goodnites.Payment.PerfectMoney.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Goodnites.Payment.PerfectMoney
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(PerfectMoneyEntityFrameworkCoreTestModule)
        )]
    public class PerfectMoneyDomainTestModule : AbpModule
    {
        
    }
}
