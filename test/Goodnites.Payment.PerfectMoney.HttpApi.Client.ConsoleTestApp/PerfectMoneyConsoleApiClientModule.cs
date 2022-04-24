using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Goodnites.Payment.PerfectMoney
{
    [DependsOn(
        typeof(PerfectMoneyHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class PerfectMoneyConsoleApiClientModule : AbpModule
    {
        
    }
}
