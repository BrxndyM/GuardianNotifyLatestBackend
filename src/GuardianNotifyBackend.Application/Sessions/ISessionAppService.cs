using System.Threading.Tasks;
using Abp.Application.Services;
using GuardianNotifyBackend.Sessions.Dto;

namespace GuardianNotifyBackend.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
