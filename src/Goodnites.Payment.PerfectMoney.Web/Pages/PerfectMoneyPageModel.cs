using Goodnites.Payment.PerfectMoney.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Goodnites.Payment.PerfectMoney.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class PerfectMoneyPageModel : AbpPageModel
    {
        protected PerfectMoneyPageModel()
        {
            LocalizationResourceType = typeof(PerfectMoneyResource);
            ObjectMapperContext = typeof(PerfectMoneyWebModule);
        }
    }
}