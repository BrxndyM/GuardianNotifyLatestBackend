using System.Threading.Tasks;
using GuardianNotifyBackend.Configuration.Dto;

namespace GuardianNotifyBackend.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
