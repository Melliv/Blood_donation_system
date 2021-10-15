using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class BloodTestMapper: BaseMapper<BLL.App.DTO.BloodTest, DAL.App.DTO.BloodTest>, IBaseMapper<BLL.App.DTO.BloodTest, DAL.App.DTO.BloodTest>
    {
        public BloodTestMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}