using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Goodnites.Payment.PerfectMoney.EntityFrameworkCore
{
    [ConnectionStringName(PerfectMoneyDbProperties.ConnectionStringName)]
    public interface IPerfectMoneyDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}