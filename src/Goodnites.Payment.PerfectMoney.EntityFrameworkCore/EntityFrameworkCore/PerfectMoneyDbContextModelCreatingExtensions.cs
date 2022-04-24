using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Goodnites.Payment.PerfectMoney.EntityFrameworkCore
{
    public static class PerfectMoneyDbContextModelCreatingExtensions
    {
        public static void ConfigurePerfectMoney(
            this ModelBuilder builder,
            Action<PerfectMoneyModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new PerfectMoneyModelBuilderConfigurationOptions(
                PerfectMoneyDbProperties.DbTablePrefix,
                PerfectMoneyDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */
        }
    }
}