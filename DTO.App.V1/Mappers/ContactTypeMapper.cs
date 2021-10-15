using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DTO.App.V1.Mappers
{
    public class ContactTypeMapper: BaseMapper<BLL.App.DTO.ContactType,DTO.App.V1.ContactType>, IBaseMapper<BLL.App.DTO.ContactType, DTO.App.V1.ContactType>
    {
        public ContactTypeMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}