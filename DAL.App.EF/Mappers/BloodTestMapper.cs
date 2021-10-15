using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class BloodTestMapper : BaseMapper<DAL.App.DTO.BloodTest, Domain.App.BloodTest>,  IBaseMapper<DAL.App.DTO.BloodTest, Domain.App.BloodTest>
    {
        public BloodTestMapper(IMapper mapper) : base(mapper)
        {
        }

    }
}