using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Goodnites.Payment.PerfectMoney
{
    [DependsOn(
        typeof(PerfectMoneyApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class PerfectMoneyHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "PerfectMoney";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(PerfectMoneyApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
