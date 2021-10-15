using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class BloodTransfusionMapper : BaseMapper<DAL.App.DTO.BloodTransfusion, Domain.App.BloodTransfusion>,  IBaseMapper<DAL.App.DTO.BloodTransfusion, Domain.App.BloodTransfusion>
    {
        public BloodTransfusionMapper(IMapper mapper) : base(mapper)
        {
        }

    }
}