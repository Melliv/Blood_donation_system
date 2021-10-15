using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DTO.App.V1.Mappers
{
    public class ContactMapper: BaseMapper<BLL.App.DTO.Contact, DTO.App.V1.Contact>, IBaseMapper<BLL.App.DTO.Contact, DTO.App.V1.Contact>

    {
        public ContactMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}