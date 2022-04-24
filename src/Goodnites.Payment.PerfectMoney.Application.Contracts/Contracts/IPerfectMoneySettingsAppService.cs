using System.Threading.Tasks;
using Goodnites.Payment.PerfectMoney.Dto;

namespace Goodnites.Payment.PerfectMoney.Contracts
{
    public interface IPerfectMoneySettingsAppService
    {
        Task<PerfectMoneySettingsDto> GetAsync();

        Task UpdateAsync(PerfectMoneySettingsDto input);
    }
}