using AutoMapper;

namespace DAL.App.DTO.MappingProfiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DAL.App.DTO.Contact, Domain.App.Contact>().ReverseMap();
            CreateMap<DAL.App.DTO.ContactType, Domain.App.ContactType>().ReverseMap();
            CreateMap<DAL.App.DTO.Person, Domain.App.Person>().ReverseMap();
            CreateMap<DAL.App.DTO.PersonType, Domain.App.PersonType>().ReverseMap();
            CreateMap<DAL.App.DTO.BloodDonate, Domain.App.BloodDonate>().ReverseMap();
            CreateMap<DAL.App.DTO.BloodGroup, Domain.App.BloodGroup>().ReverseMap();
            CreateMap<DAL.App.DTO.BloodTest, Domain.App.BloodTest>().ReverseMap();
            CreateMap<DAL.App.DTO.BloodTransfusion, Domain.App.BloodTransfusion>().ReverseMap();
            CreateMap<DAL.App.DTO.TransferableBlood, Domain.App.TransferableBlood>().ReverseMap();
            
            //CreateMap<DAL.App.DTO.Identity.AppUser, Domain.App.Identity.AppUser>().ReverseMap();
            //CreateMap<DAL.App.DTO.Identity.AppRole, Domain.App.Identity.AppRole>().ReverseMap();
        }
        
    }
}

