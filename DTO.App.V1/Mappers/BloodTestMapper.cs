using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DTO.App.V1.Mappers
{
    public class BloodTestMapper: BaseMapper<BLL.App.DTO.BloodTest, DTO.App.V1.BloodTest>, IBaseMapper<BLL.App.DTO.BloodTest, DTO.App.V1.BloodTest>
    {
        public BloodTestMapper(IMapper mapper) : base(mapper)
        {
        }

        public static BloodTest ToDTOCreate(BLL.App.DTO.BloodTest bloodTest)
        {
            return new BloodTest()
            {
                Id = bloodTest.Id,
                OverviewData = $"{bloodTest.Donor!.FullName} | {bloodTest.Doctor!.FullName} | {bloodTest.CreateAt}",
            };
        }
    }
}