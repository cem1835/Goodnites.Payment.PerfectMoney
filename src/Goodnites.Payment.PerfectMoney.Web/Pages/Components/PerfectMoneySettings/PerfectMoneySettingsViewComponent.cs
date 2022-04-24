using System.Threading.Tasks;
using Goodnites.Payment.PerfectMoney.Contracts;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Goodnites.Payment.PerfectMoney.Web.Pages.Components.PerfectMoneySettings
{
    public class PerfectMoneySettingsViewComponent:AbpViewComponent
    {
        private readonly IPerfectMoneySettingsAppService _perfectMoneySettingsAppService;

        public PerfectMoneySettingsViewComponent(IPerfectMoneySettingsAppService perfectMoneySettingsAppService)
        {
            _perfectMoneySettingsAppService = perfectMoneySettingsAppService;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _perfectMoneySettingsAppService.GetAsync();
            
            return View("~/Pages/Components/PerfectMoneySettings/Default.cshtml",model);
        }
    }
}