using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class BloodDonateMapper : BaseMapper<DAL.App.DTO.BloodDonate, Domain.App.BloodDonate>,  IBaseMapper<DAL.App.DTO.BloodDonate, Domain.App.BloodDonate>
    {
        public BloodDonateMapper(IMapper mapper) : base(mapper)
        {
        }

    }
}