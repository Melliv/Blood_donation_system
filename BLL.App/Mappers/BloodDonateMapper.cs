using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class BloodDonateMapper: BaseMapper<BLL.App.DTO.BloodDonate, DAL.App.DTO.BloodDonate>, IBaseMapper<BLL.App.DTO.BloodDonate, DAL.App.DTO.BloodDonate>
    {
        public BloodDonateMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}