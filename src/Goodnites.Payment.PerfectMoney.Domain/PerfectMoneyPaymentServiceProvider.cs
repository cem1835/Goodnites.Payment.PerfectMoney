using System;
using System.Threading.Tasks;
using EasyAbp.PaymentService.Payments;
using Volo.Abp.Data;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Users;

namespace Goodnites.Payment.PerfectMoney
{
    public class PerfectMoneyPaymentServiceProvider : PaymentServiceProvider
    {
        private readonly IPaymentManager _paymentManager;
        private readonly IPaymentRepository _paymentRepository;

        public PerfectMoneyPaymentServiceProvider(IPaymentManager paymentManager, IPaymentRepository paymentRepository)
        {
            _paymentManager = paymentManager;
            _paymentRepository = paymentRepository;
        }

        public override async Task OnPaymentStartedAsync(EasyAbp.PaymentService.Payments.Payment payment,
            ExtraPropertyDictionary configurations)
        {
            if (payment.ActualPaymentAmount <= decimal.Zero)
            {
                throw new PaymentAmountInvalidException(payment.ActualPaymentAmount, PerfectMoneyConsts.PerfectMoney);
            }

            await _paymentManager.CompletePaymentAsync(payment); // this func publish PaymentCompletedEto 

            await _paymentRepository.UpdateAsync(payment, true);
        }

        public override async Task OnCancelStartedAsync(EasyAbp.PaymentService.Payments.Payment payment)
        {
            if (payment.CanceledTime.HasValue)
            {
                return;
            }

            await _paymentManager.CompleteCancelAsync(payment);
        }
    }
}