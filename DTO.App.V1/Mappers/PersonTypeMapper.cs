using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DTO.App.V1.Mappers
{
    public class PersonTypeMapper: BaseMapper<BLL.App.DTO.PersonType, DTO.App.V1.PersonType>, IBaseMapper<BLL.App.DTO.PersonType, DTO.App.V1.PersonType>
    {
        public PersonTypeMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}