using Abp.Application.Services;
using GuardianNotifyBackend.Domain;
using GuardianNotifyBackend.Services.CloseContactsService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardianNotifyBackend.Services.CloseContactsService
{
    public interface ICloseContactAppService : IApplicationService
    {
        Task<CloseContactDto> CreateAsync(CloseContactDto input);
        Task<CloseContactDto> GetAsync(Guid id);
        Task<List<CloseContactDto>> GetAllAsync();
        Task<CloseContactDto> UpdateAsync(CloseContactDto input);
        Task Delete(Guid id);
        Task<List<CloseContactDto>> GetAllByUserIdAsync(long userId);
    }
}
