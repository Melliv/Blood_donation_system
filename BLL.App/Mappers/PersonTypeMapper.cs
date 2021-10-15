using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class PersonTypeMapper: BaseMapper<BLL.App.DTO.PersonType, DAL.App.DTO.PersonType>, IBaseMapper<BLL.App.DTO.PersonType, DAL.App.DTO.PersonType>
    {
        public PersonTypeMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}