using Goodnites.Payment.PerfectMoney.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Goodnites.Payment.PerfectMoney
{
    public abstract class PerfectMoneyController : AbpController
    {
        protected PerfectMoneyController()
        {
            LocalizationResource = typeof(PerfectMoneyResource);
        }
    }
}
