using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DTO.App.V1.Mappers
{
    public class BloodTransfusionMapper: BaseMapper<BLL.App.DTO.BloodTransfusion, DTO.App.V1.BloodTransfusion>, IBaseMapper<BLL.App.DTO.BloodTransfusion, DTO.App.V1.BloodTransfusion>
    {
        public BloodTransfusionMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}