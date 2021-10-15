using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class BloodTransfusionMapper: BaseMapper<BLL.App.DTO.BloodTransfusion, DAL.App.DTO.BloodTransfusion>, IBaseMapper<BLL.App.DTO.BloodTransfusion, DAL.App.DTO.BloodTransfusion>
    {
        public BloodTransfusionMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}