using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DTO.App.V1.Mappers
{
    public class BloodDonateMapper: BaseMapper<BLL.App.DTO.BloodDonate, DTO.App.V1.BloodDonate>, IBaseMapper<BLL.App.DTO.BloodDonate, DTO.App.V1.BloodDonate>
    {
        public BloodDonateMapper(IMapper mapper) : base(mapper)
        {
        }

    }
}
