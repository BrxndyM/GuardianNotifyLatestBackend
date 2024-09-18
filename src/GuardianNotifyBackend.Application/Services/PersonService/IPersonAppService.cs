using Abp.Application.Services;
using GuardianNotifyBackend.Services.PersonService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardianNotifyBackend.Services.PersonService
{
    public interface IPersonAppService : IApplicationService
    {
        Task<PersonDto> CreateAsync(PersonDto input);
        Task<PersonDto> GetAsync(Guid id);
        Task<List<PersonDto>> GetAllAsync();
        Task<PersonDto> UpdateAsync(PersonDto input);
        Task Delete(Guid id);
    }
}
