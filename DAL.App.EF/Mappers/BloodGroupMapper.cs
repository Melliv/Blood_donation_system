using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class BloodGroupMapper : BaseMapper<DAL.App.DTO.BloodGroup, Domain.App.BloodGroup>,  IBaseMapper<DAL.App.DTO.BloodGroup, Domain.App.BloodGroup>
    {
        public BloodGroupMapper(IMapper mapper) : base(mapper)
        {
        }

    }
}