using System;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Goodnites.Payment.PerfectMoney.Web.Pages.PerfectMoney
{
    public class Redirect : AbpPageModel
    {
        public PerfectMoneyRequestModel RequestModel { get; set; }

        public void OnGet(string payeeAccount, Guid paymentId, string paymentAmount)
        {
            RequestModel = new(payeeAccount, paymentId, paymentAmount);
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            return NoContent();
        }
    }
}