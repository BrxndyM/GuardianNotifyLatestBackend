using System.Threading.Tasks;
using Abp.Application.Services;
using GuardianNotifyBackend.Authorization.Accounts.Dto;

namespace GuardianNotifyBackend.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
