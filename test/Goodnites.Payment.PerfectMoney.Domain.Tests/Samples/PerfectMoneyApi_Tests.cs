using System;
using System.Collections.Generic;
using Xunit;

namespace Goodnites.Payment.PerfectMoney.Samples;

public class PerfectMoneyApi_Tests
{
    private PerfectMoneyApi _perfectMoneyApi;

    public PerfectMoneyApi_Tests()
    {
        _perfectMoneyApi = new PerfectMoneyApi();
    }

    public static IEnumerable<object[]> PerfectMoneyModels()
    {
        yield return new object[]
        {
            new PerfectMoneyModel()
            {
            PaymentId = Guid.Parse("3a035f67-6dc7-4616-8976-c4e52cdd1130"),
            PayeeAccount = "U34415558",
            PayerAccount = "U34415558",
            PassPhrase = "6rH09Ep68TnRTwcPyepoRToKx",
            PaymentBatchNumber = "459587619",
            TimeStampGmt = "1650555389",
             PaymentAmount = "1.00",
             PaymentUnits = "USD",
             V2Hash = "200E116DB097E3A3B8DFD1ED7835A4EA"
            }
        };
    }

    [Theory]
    [MemberData(nameof(PerfectMoneyModels))]

    public void V2_Hash_Should_Be_Successful(PerfectMoneyModel model)
    {
        var result =_perfectMoneyApi.IsValidHash(model);
        
        Assert.True(result);
    }
}