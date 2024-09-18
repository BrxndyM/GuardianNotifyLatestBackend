using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GuardianNotifyBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GuardianNotifyBackend.Services.CloseContactsService.Dtos
{
    [AutoMapFrom(typeof(CloseContact))]
    public class CloseContactDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CellNumber { get; set; }
        public string EmailAddress { get; set; }

        public Guid PersonId { get; set; }
    }
}
