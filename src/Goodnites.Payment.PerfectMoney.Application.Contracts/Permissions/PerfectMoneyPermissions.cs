using Volo.Abp.Reflection;

namespace Goodnites.Payment.PerfectMoney.Permissions
{
    public class PerfectMoneyPermissions
    {
        public const string GroupName = "PerfectMoney";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(PerfectMoneyPermissions));
        }
        
        public const string ApiSetting = "PerfectMoneySettingsAuth";
    }
}