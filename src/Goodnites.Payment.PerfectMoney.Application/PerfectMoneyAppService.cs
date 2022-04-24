using Goodnites.Payment.PerfectMoney.Localization;
using Volo.Abp.Application.Services;

namespace Goodnites.Payment.PerfectMoney
{
    public abstract class PerfectMoneyAppService : ApplicationService
    {
        protected PerfectMoneyAppService()
        {
            LocalizationResource = typeof(PerfectMoneyResource);
            ObjectMapperContext = typeof(PerfectMoneyApplicationModule);
        }
    }
}
