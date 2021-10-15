using AutoMapper;
using BLL.App.DTO.Identity;

namespace BLL.App.DTO.MappingProfiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppUser, DAL.App.DTO.Identity.AppUser>().ReverseMap();
            CreateMap<AppRole, DAL.App.DTO.Identity.AppRole>().ReverseMap();
            
            CreateMap<Person, DAL.App.DTO.Person>().ReverseMap();
            CreateMap<PersonType, DAL.App.DTO.PersonType>().ReverseMap();
            CreateMap<BloodDonate, DAL.App.DTO.BloodDonate>().ReverseMap();
            CreateMap<BloodGroup, DAL.App.DTO.BloodGroup>().ReverseMap();
            CreateMap<BloodTest, DAL.App.DTO.BloodTest>().ReverseMap();
            CreateMap<BloodTransfusion, DAL.App.DTO.BloodTransfusion>().ReverseMap();
            CreateMap<Contact, DAL.App.DTO.Contact>().ReverseMap();
            CreateMap<ContactType, DAL.App.DTO.ContactType>().ReverseMap();
            CreateMap<TransferableBlood, DAL.App.DTO.TransferableBlood>().ReverseMap();
        }
    }
}

