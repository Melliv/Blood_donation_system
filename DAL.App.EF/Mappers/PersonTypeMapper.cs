using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class PersonTypeMapper : BaseMapper<DAL.App.DTO.PersonType, Domain.App.PersonType>,  IBaseMapper<DAL.App.DTO.PersonType, Domain.App.PersonType>
    {
        public PersonTypeMapper(IMapper mapper) : base(mapper)
        {
        }

    }
}