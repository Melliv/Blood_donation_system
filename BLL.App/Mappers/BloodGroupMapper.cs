using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class BloodGroupMapper: BaseMapper<BLL.App.DTO.BloodGroup, DAL.App.DTO.BloodGroup>, IBaseMapper<BLL.App.DTO.BloodGroup, DAL.App.DTO.BloodGroup>
    {
        public BloodGroupMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}