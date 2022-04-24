using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Goodnites.Payment.PerfectMoney.EntityFrameworkCore
{
    [ConnectionStringName(PerfectMoneyDbProperties.ConnectionStringName)]
    public class PerfectMoneyDbContext : AbpDbContext<PerfectMoneyDbContext>, IPerfectMoneyDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public PerfectMoneyDbContext(DbContextOptions<PerfectMoneyDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigurePerfectMoney();
        }
    }
}