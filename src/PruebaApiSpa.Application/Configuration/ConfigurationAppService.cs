using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using PruebaApiSpa.Configuration.Dto;

namespace PruebaApiSpa.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : PruebaApiSpaAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
