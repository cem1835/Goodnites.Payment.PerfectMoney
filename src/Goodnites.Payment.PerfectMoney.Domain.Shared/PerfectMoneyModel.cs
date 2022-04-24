using System;

namespace Goodnites.Payment.PerfectMoney
{
    public class PerfectMoneyModel
    {
        public Guid PaymentId { get; set; }
        public string PayeeAccount { get; set; }
        public string PaymentAmount { get; set; }
        public string PaymentUnits { get; set; }
        public string PaymentBatchNumber { get; set; }
        public string PayerAccount { get; set; }
        public string PassPhrase { get; set; }
        public string TimeStampGmt { get; set; }
        public string V2Hash { get; set; }
        
    }
}