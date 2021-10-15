using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class ContactTypeMapper : BaseMapper<DAL.App.DTO.ContactType, Domain.App.ContactType>,  IBaseMapper<DAL.App.DTO.ContactType, Domain.App.ContactType>
    {
    public ContactTypeMapper(IMapper mapper) : base(mapper)
    {
    }

    }
}