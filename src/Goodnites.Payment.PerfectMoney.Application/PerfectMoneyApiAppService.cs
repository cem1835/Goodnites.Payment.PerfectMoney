using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.PaymentService.Payments;
using Goodnites.Payment.PerfectMoney.Contracts;
using Goodnites.Payment.PerfectMoney.Settings;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Security.Encryption;
using Volo.Abp.SettingManagement;
using Volo.Abp.Users;

namespace Goodnites.Payment.PerfectMoney
{
    public class PerfectMoneyApiAppService : IPerfectMoneyApiAppService
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly ICurrentTenant _currentTenant;
        private readonly ICurrentUser _currentUser;
        private readonly IDistributedEventBus _distributedEventBus;
        private readonly IPaymentManager _paymentManager;
        private readonly ISettingManager _settingManager;
        private readonly PerfectMoneyApi _perfectMoneyApi;
        private readonly IPerfectMoneyPaymentRepository _perfectMoneyPaymentRepository;
        private readonly ILogger<PerfectMoneyApiAppService> _logger;

        public PerfectMoneyApiAppService(
            ISettingManager settingManager,
            IPaymentManager paymentManager,
            IDistributedEventBus distributedEventBus,
            ICurrentUser currentUser,
            ICurrentTenant currentTenant,
            IGuidGenerator guidGenerator,
            IPerfectMoneyPaymentRepository perfectMoneyPaymentRepository, ILogger<PerfectMoneyApiAppService> logger)
        {
            _settingManager = settingManager;
            _paymentManager = paymentManager;
            _distributedEventBus = distributedEventBus;
            _currentUser = currentUser;
            _currentTenant = currentTenant;
            _guidGenerator = guidGenerator;
            _perfectMoneyApi = new PerfectMoneyApi();
            _perfectMoneyPaymentRepository = perfectMoneyPaymentRepository;
            _logger = logger;
        }


        public async Task<PerfectMoneyRequestModel> CreateChargeAsync(string amountStr, string currency,
            string description)
        {
            if (decimal.TryParse(amountStr, out decimal amount) == false)
            {
                throw new UserFriendlyException("Your amount is invalid");
            }

            await CheckMinMaxValuesAsync(amount).ConfigureAwait(false);

            var perfectMoneyPaymentId = _guidGenerator.Create();

            var perfectMoneyRequest = new PerfectMoneyRequestModel(
                payeeAccount: (await _settingManager.GetOrNullAsync(PerfectMoneySettings.PerfectUserId, "G", null)),
                paymentId: perfectMoneyPaymentId,
                paymentAmount: amountStr
            );

            var createPaymentEto = new CreatePaymentEto(
                _currentTenant.Id,
                _currentUser.GetId(),
                PerfectMoneyConsts.PerfectMoney,
                currency,
                new List<CreatePaymentItemEto>()
                {
                    new CreatePaymentItemEto
                    {
                        ItemType = "FUND",
                        ItemKey = perfectMoneyPaymentId.ToString(),
                        OriginalPaymentAmount = Convert.ToDecimal(amount),
                    }
                }
            );

            createPaymentEto.SetProperty("FUND", true);
            createPaymentEto.SetProperty("PerfectMoneyPaymentId", perfectMoneyPaymentId);
            createPaymentEto.SetProperty("PaymentMethod", PerfectMoneyConsts.PerfectMoney);
            createPaymentEto.SetProperty("PerfectMoneyRequest", perfectMoneyRequest);

            await _distributedEventBus.PublishAsync(createPaymentEto);

            return perfectMoneyRequest;
        }

        private async Task CheckMinMaxValuesAsync(decimal amount)
        {
            var min =
                await _settingManager.GetOrNullAsync(PerfectMoneySettings.Min, "G", null, true);

            var max = await _settingManager.GetOrNullAsync(PerfectMoneySettings.Max, "G", null, true);


            if (decimal.Parse(min) <= amount && amount <= decimal.Parse(max))
            {
            }
            else
            {
                throw new UserFriendlyException($"Accepted Values Between {min} - {max}");
            }
        }

        public async Task WebHookAsync(PerfectMoneyModel perfectMoneyResponseModel, string clientIp)
        {
            // var ipIsValid = await _perfectMoneyApi.IpIsValid(clientIp);
            //
            // if (ipIsValid == false)
            // {
            //     throw new UserFriendlyException("Invalid Client Ip");
            // }

            perfectMoneyResponseModel.PassPhrase =
                await _settingManager.GetOrNullAsync(PerfectMoneySettings.PassPhrase, "G", null);

            _logger.LogWarning("Pass Phrase : {PassPhrase}",perfectMoneyResponseModel.PassPhrase);
            
            var hashValid = _perfectMoneyApi.IsValidHash(perfectMoneyResponseModel);

            _logger.LogWarning("Has Valid {HashValid}", hashValid);

            if (hashValid == false)
            {
                throw new UserFriendlyException("Invalid Hash");
            }

            // TODO : Will change
            var perfectPayments = await _perfectMoneyPaymentRepository.GetPerfectPaymentsAsync();

            var payment =
                perfectPayments.FirstOrDefault(
                    x => x.GetProperty("PerfectMoneyPaymentId", "") == perfectMoneyResponseModel.PaymentId.ToString());
            

            if (payment.CompletionTime != null)
            {
                return;
            }
            
            _logger.LogWarning("Payment Completing..");
            
            var extraPropertyDictionary = new ExtraPropertyDictionary()
            {
                { PerfectMoneyConsts.UserId, payment.UserId },
                { PerfectMoneyConsts.PerfectMoneyStatus, "Success" }
            };

            await _paymentManager.StartPaymentAsync(payment, extraPropertyDictionary);
        }
    }
}