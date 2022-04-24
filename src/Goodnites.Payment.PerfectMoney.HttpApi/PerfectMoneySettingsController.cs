using System.Threading.Tasks;
using Goodnites.Payment.PerfectMoney.Contracts;
using Goodnites.Payment.PerfectMoney.Dto;
using Goodnites.Payment.PerfectMoney.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Goodnites.Payment.PerfectMoney
{
    
    [RemoteService(Name = "GoodnitesPerfectMoneySetting")]
    [Microsoft.AspNetCore.Components.Route("/api/perfectMoneySetting")]
    [Authorize(PerfectMoneyPermissions.ApiSetting)]
    public class PerfectMoneySettingsController:AbpController,IPerfectMoneySettingsAppService
    {
        private readonly IPerfectMoneySettingsAppService _perfectMoneySettingsAppService;

        public PerfectMoneySettingsController(IPerfectMoneySettingsAppService perfectMoneySettingsAppService)
        {
            _perfectMoneySettingsAppService = perfectMoneySettingsAppService;
        }

        [HttpGet]
        public Task<PerfectMoneySettingsDto> GetAsync()
        {
            return _perfectMoneySettingsAppService.GetAsync();
        }

        [HttpPut]
        public async Task UpdateAsync(PerfectMoneySettingsDto input)
        {
            await _perfectMoneySettingsAppService.UpdateAsync(input);
        }
    }
}