using Abp.Application.Services;
using Abp.Domain.Repositories;
using GuardianNotifyBackend.Domain;
using GuardianNotifyBackend.Services.LocationService.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardianNotifyBackend.Services.LocationService
{
    public class LocationAppService : ApplicationService, ILocationAppService
    {
        private readonly IRepository<Location, Guid> _locationRepository;

        public LocationAppService(IRepository<Location, Guid> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpPost]
        public async Task<LocationDto> CreateAsync(LocationDto input)
        {
            return ObjectMapper.Map<LocationDto>(await _locationRepository.InsertAsync(ObjectMapper.Map<Location>(input)));
        }

        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _locationRepository.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<List<LocationDto>> GetAllAsync()
        {
            return ObjectMapper.Map<List<LocationDto>>(await _locationRepository.GetAllListAsync());
        }

        [HttpGet]
        public async Task<LocationDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<LocationDto>(await _locationRepository.GetAsync(id));
        }

        [HttpPut]
        public async Task<LocationDto> UpdateAsync(LocationDto input)
        {
            var location = await _locationRepository.GetAsync(input.Id);
            ObjectMapper.Map(location, input);
            return ObjectMapper.Map<LocationDto>(location);
        }
    }
}
