using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GuardianNotifyBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GuardianNotifyBackend.Services.LocationService.Dtos
{
    [AutoMapFrom(typeof(Location))]
    public class LocationDto : EntityDto<Guid>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Timestamp { get; set; }
        public Person Person { get; set; }
    }
}
