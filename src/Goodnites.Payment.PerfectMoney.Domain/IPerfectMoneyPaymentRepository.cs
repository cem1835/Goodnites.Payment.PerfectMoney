using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Goodnites.Payment.PerfectMoney
{
    public interface IPerfectMoneyPaymentRepository
    {
        Task<EasyAbp.PaymentService.Payments.Payment> GetAsync(Guid id);
        
        Task<List<EasyAbp.PaymentService.Payments.Payment>> GetPerfectPaymentsByUserIdAsync(Guid userId);

        Task<List<EasyAbp.PaymentService.Payments.Payment>> GetPerfectPaymentsAsync();

    }
}