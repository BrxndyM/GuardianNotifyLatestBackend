using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using GuardianNotifyBackend.Domain;
using GuardianNotifyBackend.Services.CloseContactsService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardianNotifyBackend.Services.CloseContactsService
{
    public class CloseContactAppService : ApplicationService, ICloseContactAppService
    {
        private readonly IRepository<CloseContact, Guid> _closeContactsRepository;
        private readonly IRepository<Person, Guid> _personRepository;

        public CloseContactAppService(IRepository<CloseContact, Guid> closeContactsRepository, IRepository<Person, Guid> personRepository)
        {
            _closeContactsRepository = closeContactsRepository;
            _personRepository = personRepository;
        }

        public async Task<CloseContactDto> CreateAsync(CloseContactDto input)
        {
            var currentPerson = await GetCurrentPersonAsync();
            var closeContact = ObjectMapper.Map<CloseContact>(input);
            closeContact.Person = currentPerson;
            var createdCloseContact = await _closeContactsRepository.InsertAsync(closeContact);
            return ObjectMapper.Map<CloseContactDto>(createdCloseContact);
        }

        public async Task Delete(Guid id)
        {
            await _closeContactsRepository.DeleteAsync(id);
        }

        public async Task<List<CloseContactDto>> GetAllAsync()
        {
            return ObjectMapper.Map<List<CloseContactDto>>(await _closeContactsRepository.GetAllListAsync());
        }

        public async Task<CloseContactDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CloseContactDto>(await _closeContactsRepository.GetAsync(id));
        }

        public async Task<CloseContactDto> UpdateAsync(CloseContactDto input)
        {
            var currentPerson = await GetCurrentPersonAsync();
            var closeContact = await _closeContactsRepository.GetAsync(input.Id);

            if (closeContact.Person.Id != currentPerson.Id)
            {
                throw new UserFriendlyException("You are not authorized to update this contact.");
            }

            ObjectMapper.Map(input, closeContact);
            await _closeContactsRepository.UpdateAsync(closeContact);
            return ObjectMapper.Map<CloseContactDto>(closeContact);
        }

        public async Task<List<CloseContactDto>> GetAllByCurrentPersonAsync()
        {
            var currentPerson = await GetCurrentPersonAsync();
            var contacts = await _closeContactsRepository.GetAllListAsync(c => c.Person.Id == currentPerson.Id);
            return ObjectMapper.Map<List<CloseContactDto>>(contacts);
        }

        private async Task<Person> GetCurrentPersonAsync()
        {
            var currentPerson = await _personRepository.FirstOrDefaultAsync(p => p.User.Id == AbpSession.UserId);
            if (currentPerson == null)
            {
                throw new UserFriendlyException("Current person not found.");
            }
            return currentPerson;
        }
    }
}
git remote add origin https://github.com/BrxndyM/GurdianNotifyLatestBackend.git
git branch -M main
git push -u origin main