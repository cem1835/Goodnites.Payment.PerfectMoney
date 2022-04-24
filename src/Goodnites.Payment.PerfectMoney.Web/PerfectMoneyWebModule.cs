using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Goodnites.Payment.PerfectMoney.Localization;
using Goodnites.Payment.PerfectMoney.Web.Menus;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Goodnites.Payment.PerfectMoney.Permissions;
using Goodnites.Payment.PerfectMoney.Web.Settings;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;

namespace Goodnites.Payment.PerfectMoney.Web
{
    [DependsOn(
        typeof(PerfectMoneyHttpApiModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
        typeof(AbpAutoMapperModule)
        )]
    public class PerfectMoneyWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(PerfectMoneyResource), typeof(PerfectMoneyWebModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(PerfectMoneyWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new PerfectMoneyMenuContributor());
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<PerfectMoneyWebModule>();
            });

            context.Services.AddAutoMapperObjectMapper<PerfectMoneyWebModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<PerfectMoneyWebModule>(validate: true);
            });

            Configure<SettingManagementPageOptions>(opt =>
            {
                opt.Contributors.Add(new PerfectMoneySettingPageContributor());
                 
            });
            
            
            
            Configure<AbpBundlingOptions>(opt =>
            {
                opt.ScriptBundles.Configure(typeof(IndexModel).FullName,
                    configure =>
                    {
                        configure.AddFiles("/Pages/Components/PerfectMoneySettings/Default.js");
                    });
            });
            
            Configure<RazorPagesOptions>(options =>
            {
                //Configure authorization.
            });
        }
    }
}
