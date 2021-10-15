using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DTO.App.V1.Mappers
{
    public class BloodGroupMapper: BaseMapper<BLL.App.DTO.BloodGroup, DTO.App.V1.BloodGroup>, IBaseMapper<BLL.App.DTO.BloodGroup, DTO.App.V1.BloodGroup>
    {
        public BloodGroupMapper(IMapper mapper) : base(mapper)
        {
        }
        
    }
}