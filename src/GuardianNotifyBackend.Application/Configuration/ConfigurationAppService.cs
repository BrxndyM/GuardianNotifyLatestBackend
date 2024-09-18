using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using GuardianNotifyBackend.Configuration.Dto;

namespace GuardianNotifyBackend.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : GuardianNotifyBackendAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
