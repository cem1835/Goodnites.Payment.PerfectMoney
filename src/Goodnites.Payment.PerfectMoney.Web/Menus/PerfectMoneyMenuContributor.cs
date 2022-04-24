using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Goodnites.Payment.PerfectMoney.Web.Menus
{
    public class PerfectMoneyMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            return Task.CompletedTask;
        }
    }
}