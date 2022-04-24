using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.PaymentService.EntityFrameworkCore;
using EasyAbp.PaymentService.Payments;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;

namespace Goodnites.Payment.PerfectMoney
{
    public class PerfectMoneyPaymentRepository:PaymentRepository,IPerfectMoneyPaymentRepository,ITransientDependency
    {
        public PerfectMoneyPaymentRepository(IDbContextProvider<IPaymentServiceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        
        public async Task<EasyAbp.PaymentService.Payments.Payment> GetAsync(Guid id)
        {
            var dbSet = await GetDbSetAsync();

            var payment = await dbSet.Where(x => x.Id==id)
                .FirstOrDefaultAsync();

            return payment;
        }

        public async Task<List<EasyAbp.PaymentService.Payments.Payment>> GetPerfectPaymentsByUserIdAsync(Guid userId)
        {
            var dbSet = await GetDbSetAsync();

            var payments = await dbSet.Where(x => x.UserId == userId && x.PaymentMethod == PerfectMoneyConsts.PerfectMoney)
                .ToListAsync().ConfigureAwait(false);

            return payments;
        }
        
        public async Task<List<EasyAbp.PaymentService.Payments.Payment>> GetPerfectPaymentsAsync()
        {
            var dbSet = await GetDbSetAsync();

            var payments = await dbSet.Where(x => x.PaymentMethod == PerfectMoneyConsts.PerfectMoney)
                .ToListAsync().ConfigureAwait(false);

            return payments;
        }
    }
}