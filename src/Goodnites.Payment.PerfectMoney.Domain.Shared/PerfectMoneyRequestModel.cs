using System;

namespace Goodnites.Payment.PerfectMoney
{
    public class PerfectMoneyRequestModel
    {
        public string PayeeAccount { get; set; }
        public Guid PaymentId { get; set; }
        public string PaymentAmount { get; set; }
        public string PaymentUnit => "USD";


        protected PerfectMoneyRequestModel()
        {
            
        }

        public PerfectMoneyRequestModel(string payeeAccount,Guid paymentId,string paymentAmount)
        {
            PayeeAccount = payeeAccount;
            PaymentId = paymentId;
            PaymentAmount = paymentAmount;
        }
    }
}