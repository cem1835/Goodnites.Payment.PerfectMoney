using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Goodnites.Payment.PerfectMoney.Contracts
{
    public interface IPerfectMoneyApiAppService:ITransientDependency
    {
        Task<PerfectMoneyRequestModel> CreateChargeAsync(string amountStr, string currency,
            string description);

        Task WebHookAsync(PerfectMoneyModel perfectMoneyResponseModel, string clientIp);
    }
}