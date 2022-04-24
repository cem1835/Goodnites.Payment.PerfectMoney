using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Goodnites.Payment.PerfectMoney.EntityFrameworkCore
{
    public class PerfectMoneyModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public PerfectMoneyModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}