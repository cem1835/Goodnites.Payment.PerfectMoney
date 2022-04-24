using System;
using System.Linq;
using System.Threading.Tasks;
using Goodnites.Payment.PerfectMoney.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;

namespace Goodnites.Payment.PerfectMoney.Web.Pages.PerfectMoney
{
    [IgnoreAntiforgeryToken]
    public class Success : PageModel
    {
        private readonly IPerfectMoneyApiAppService _perfectMoneyApiAppService;
        private readonly ILogger<Success> _logger;

        public Success(IPerfectMoneyApiAppService perfectMoneyApiAppService, ILogger<Success> logger)
        {
            _perfectMoneyApiAppService = perfectMoneyApiAppService;
            _logger = logger;
        }

        public  void OnGet()
        {
   
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            _logger.LogError($"{ip}");
            _logger.LogWarning(JsonConvert.SerializeObject(Request.Form));
            
            var clientIp = HttpContext.Connection.RemoteIpAddress.ToString();

            await _perfectMoneyApiAppService.WebHookAsync(GetModel(), clientIp);

            return Redirect("/PerfectMoney/Success");
        }

        private PerfectMoneyModel GetModel()
        {
            return new PerfectMoneyModel()
            {
                PaymentId = Guid.Parse(Request.Form["PAYMENT_ID"].FirstOrDefault()),
                PayeeAccount = Request.Form["PAYEE_ACCOUNT"].ToString(),
                PaymentAmount = Request.Form["PAYMENT_AMOUNT"].ToString(),
                PaymentUnits = Request.Form["PAYMENT_UNITS"].ToString(),
                PaymentBatchNumber = Request.Form["PAYMENT_BATCH_NUM"].ToString(),
                PayerAccount =  Request.Form["PAYER_ACCOUNT"].ToString(),
                TimeStampGmt = Request.Form["TIMESTAMPGMT"].ToString(),
                V2Hash = Request.Form["V2_HASH"].ToString(),
            };
        }
    }
}