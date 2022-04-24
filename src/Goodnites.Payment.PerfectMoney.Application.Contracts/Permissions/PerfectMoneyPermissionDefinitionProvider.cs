using Goodnites.Payment.PerfectMoney.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Goodnites.Payment.PerfectMoney.Permissions
{
    public class PerfectMoneyPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var perfectMoneyGroup = context.AddGroup(PerfectMoneyPermissions.GroupName, L("Permission:PerfectMoney"));

            perfectMoneyGroup .AddPermission(PerfectMoneyPermissions.ApiSetting, L("PerfectMoneySettings"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<PerfectMoneyResource>(name);
        }
    }
}