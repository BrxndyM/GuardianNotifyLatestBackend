using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using GuardianNotifyBackend.Domain;
using GuardianNotifyBackend.Services.CloseContactsService.Dtos;
using GuardianNotifyBackend.Services.NotificationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IEmailNotificationSender  _emailSender;

        public CloseContactAppService(IRepository<CloseContact, Guid> closeContactsRepository, IRepository<Person, Guid> personRepository, IEmailNotificationSender emailSender)
        {
            _closeContactsRepository = closeContactsRepository;
            _personRepository = personRepository;
            _emailSender = emailSender;
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
        public async Task<List<CloseContactDto>> GetAllByUserIdAsync(long userId)
        {
            var person = await _personRepository.FirstOrDefaultAsync(p => p.User.Id == userId);
            if (person == null)
            {
                throw new Exception("Person not found");
            }

            var contacts = await _closeContactsRepository.GetAllListAsync(c => c.Person.Id == person.Id);
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

        public async Task<IActionResult> SendNotificationsToContacts(long userId, [FromBody] string message)
        {
            try
            {
                var contacts = await GetAllByUserIdAsync(userId);
                if (contacts == null || !contacts.Any())
                {
                    return new NotFoundObjectResult("No contacts found for this user.");
                }

                var results = new List<EmailResult>();
                foreach (var emailAddress in contacts.Select(c => c.EmailAddress))
                {
                    var result = await _emailSender.SendEmailNotificationAsync(emailAddress, message);
                    results.Add(result);
                }

                // Check if any emails failed
                if (results.Any(r => !r.Success))
                {
                    return new ObjectResult(new
                    {
                        message = "Some notifications failed to send",
                        results = results
                    })
                    {
                        StatusCode = 207 // MultiStatus
                    };
                }

                return new OkObjectResult(new
                {
                    message = "All notifications sent successfully",
                    results = results
                });
            }
            catch (Exception ex)
            {
                // Log the exception here
                return new ObjectResult(new
                {
                    message = "An error occurred while processing notifications",
                    error = ex.Message
                })
                {
                    StatusCode = 500 // Internal Server Error
                };
            }
        }

    }
}
