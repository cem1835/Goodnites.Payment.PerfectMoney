using Volo.Abp.Settings;

namespace Goodnites.Payment.PerfectMoney.Settings
{
    public class PerfectMoneySettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(new SettingDefinition(PerfectMoneySettings.PerfectUserId,isEncrypted:true));
            context.Add(new SettingDefinition(PerfectMoneySettings.PassPhrase,isEncrypted:true));
            context.Add(new SettingDefinition(PerfectMoneySettings.Min));
            context.Add(new SettingDefinition(PerfectMoneySettings.Max));
        }
    }
}