using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Goodnites.Payment.PerfectMoney.EntityFrameworkCore
{
    [DependsOn(
        typeof(PerfectMoneyDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class PerfectMoneyEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<PerfectMoneyDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
            });
        }
    }
}