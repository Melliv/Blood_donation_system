using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class ContactMapper : BaseMapper<DAL.App.DTO.Contact, Domain.App.Contact>,  IBaseMapper<DAL.App.DTO.Contact, Domain.App.Contact>
    {
        public ContactMapper(IMapper mapper) : base(mapper)
        {
        }

    }
}