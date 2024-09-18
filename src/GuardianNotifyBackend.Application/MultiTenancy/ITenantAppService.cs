using Abp.Application.Services;
using GuardianNotifyBackend.MultiTenancy.Dto;

namespace GuardianNotifyBackend.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

