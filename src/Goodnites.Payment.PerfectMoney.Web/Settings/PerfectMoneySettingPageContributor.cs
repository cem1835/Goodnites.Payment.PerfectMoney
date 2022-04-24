using System.Threading.Tasks;
using Goodnites.Payment.PerfectMoney.Localization;
using Goodnites.Payment.PerfectMoney.Permissions;
using Goodnites.Payment.PerfectMoney.Web.Pages.Components.PerfectMoneySettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;

namespace Goodnites.Payment.PerfectMoney.Web.Settings
{
    public class PerfectMoneySettingPageContributor:ISettingPageContributor
    {
        public Task ConfigureAsync(SettingPageCreationContext context)
        {
            var localizer = context.ServiceProvider.GetRequiredService<IStringLocalizer<PerfectMoneyResource>>();
            
            context.Groups.Add(new SettingPageGroup("PerfectMoneySettings", localizer["Perfect Money Settings"], typeof(PerfectMoneySettingsViewComponent)));

            return Task.CompletedTask;
        }

        public async Task<bool> CheckPermissionsAsync(SettingPageCreationContext context)
        {
            var authorizationService = context.ServiceProvider.GetRequiredService<IAuthorizationService>();
            return await authorizationService.IsGrantedAsync(PerfectMoneyPermissions.ApiSetting);
        }
    }
}