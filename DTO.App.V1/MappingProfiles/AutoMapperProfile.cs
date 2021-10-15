using System.Collections.Generic;
using AutoMapper;

namespace DTO.App.V1.MappingProfiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BLL.App.DTO.Contact, DTO.App.V1.Contact>().ReverseMap();
            CreateMap<BLL.App.DTO.Person, DTO.App.V1.Person>().ReverseMap();
            CreateMap<BLL.App.DTO.PersonType, DTO.App.V1.PersonType>().ReverseMap();
            CreateMap<BLL.App.DTO.BloodDonate, DTO.App.V1.BloodDonate>().ReverseMap();
            CreateMap<BLL.App.DTO.BloodGroup, DTO.App.V1.BloodGroup>().ReverseMap();
            CreateMap<BLL.App.DTO.BloodTest, DTO.App.V1.BloodTest>().ReverseMap();
            CreateMap<BLL.App.DTO.BloodTransfusion, DTO.App.V1.BloodTransfusion>().ReverseMap();
            CreateMap<BLL.App.DTO.ContactType, DTO.App.V1.ContactType>().ReverseMap();
            CreateMap<BLL.App.DTO.TransferableBlood, DTO.App.V1.TransferableBlood>().ReverseMap();
            
            CreateMap<Domain.App.Identity.AppUser, DTO.App.V1.AppUser>().ReverseMap();
            //CreateMap<DAL.App.DTO.Identity.AppRole, Domain.App.Identity.AppRole>().ReverseMap();
        }
        
    }
}

