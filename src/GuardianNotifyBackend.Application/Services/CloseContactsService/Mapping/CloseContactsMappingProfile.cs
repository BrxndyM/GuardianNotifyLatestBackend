using AutoMapper;
using GuardianNotifyBackend.Domain;
using GuardianNotifyBackend.Services.CloseContactsService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardianNotifyBackend.Services.CloseContactsService.Mapping
{
    public class CloseContactsMappingProfile : Profile
    {
        public CloseContactsMappingProfile()
        {
            //CreateMap<CloseContact, CloseContactDto>()
            //    .ForMember(x => x.CellNumber, m => m.MapFrom(x => x.CellNumber))
            //    .ForMember(x => x.EmailAddress, m => m.MapFrom(x => x.EmailAddress))
            //    .ForMember(x => x.Name, m => m.MapFrom(x => x.Name))
            //    .ForMember(x => x.Surname, m => m.MapFrom(x => x.Surname))
            //    .ForMember(x => x.PersonId, m => m.MapFrom(x => x.Person.Id));

            //CreateMap<CloseContactDto, CloseContact>()
            //    .ForMember(e => e.Id, d => d.Ignore())
            //    .ForMember(x => x.CellNumber, m => m.MapFrom(x => x.CellNumber))
            //    .ForMember(x => x.Surname, m => m.MapFrom(x => x.Surname))
            //    .ForMember(x => x.Name, m => m.MapFrom(x => x.Name))
            //    .ForMember(x => x.EmailAddress, m => m.MapFrom(x => x.EmailAddress));

            CreateMap<CloseContact, CloseContactDto>()
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.Person.Id));

            CreateMap<CloseContactDto, CloseContact>()
                .ForMember(dest => dest.Person, opt => opt.Ignore());
        }
    }
}
