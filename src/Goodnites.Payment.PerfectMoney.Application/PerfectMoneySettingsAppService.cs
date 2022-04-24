using System.Threading.Tasks;
using Goodnites.Payment.PerfectMoney.Contracts;
using Goodnites.Payment.PerfectMoney.Dto;
using Goodnites.Payment.PerfectMoney.Settings;
using Volo.Abp.MultiTenancy;
using Volo.Abp.SettingManagement;

namespace Goodnites.Payment.PerfectMoney
{
    public class PerfectMoneySettingsAppService : PerfectMoneyAppService, IPerfectMoneySettingsAppService
    {
        protected readonly ISettingManager SettingManager;

        public PerfectMoneySettingsAppService(ISettingManager settingManager)
        {
            SettingManager = settingManager;
        }

        public virtual async Task<PerfectMoneySettingsDto> GetAsync()
        {
            var settingsDto = new PerfectMoneySettingsDto()
            {
                PerfectUserId = await SettingProvider.GetOrNullAsync(PerfectMoneySettings.PerfectUserId),
                PassPhrase = await SettingProvider.GetOrNullAsync(PerfectMoneySettings.PassPhrase),
                Min = await SettingProvider.GetOrNullAsync(PerfectMoneySettings.Min),
                Max = await SettingProvider.GetOrNullAsync(PerfectMoneySettings.Max),
            };

            if (CurrentTenant.IsAvailable)
            {
                settingsDto.PerfectUserId =
                    await SettingManager.GetOrNullForTenantAsync(PerfectMoneySettings.PerfectUserId,
                        CurrentTenant.GetId(),
                        false);

                settingsDto.PassPhrase = await SettingManager.GetOrNullForTenantAsync(
                    PerfectMoneySettings.PassPhrase,
                    CurrentTenant.GetId(), false);

                settingsDto.Min = await SettingManager.GetOrNullForTenantAsync(
                    PerfectMoneySettings.Min,
                    CurrentTenant.GetId(), false);

                settingsDto.Max = await SettingManager.GetOrNullForTenantAsync(
                    PerfectMoneySettings.Max,
                    CurrentTenant.GetId(), false);
            }

            return settingsDto;
        }

        public virtual async Task UpdateAsync(PerfectMoneySettingsDto input)
        {
            if (CurrentTenant.Id.HasValue)
            {
                await SettingManager.SetForTenantAsync(CurrentTenant.Id.Value, PerfectMoneySettings.PerfectUserId,
                    input.PerfectUserId);

                await SettingManager.SetForTenantAsync(CurrentTenant.Id.Value, PerfectMoneySettings.PassPhrase,
                    input.PassPhrase);

                await SettingManager.SetForTenantAsync(CurrentTenant.Id.Value, PerfectMoneySettings.Min,
                    input.Min);

                await SettingManager.SetForTenantAsync(CurrentTenant.Id.Value, PerfectMoneySettings.Max,
                    input.Max);
            }
            else
            {
                await SettingManager.SetGlobalAsync(PerfectMoneySettings.PerfectUserId, input.PerfectUserId);
                await SettingManager.SetGlobalAsync(PerfectMoneySettings.PassPhrase, input.PassPhrase);
                await SettingManager.SetGlobalAsync(PerfectMoneySettings.Min, input.Min);
                await SettingManager.SetGlobalAsync(PerfectMoneySettings.Max, input.Max);
            }
        }
    }
}