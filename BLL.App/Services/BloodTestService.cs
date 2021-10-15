using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace BLL.App.Services
{
    public class BloodTestService: BaseEntityService<IAppUnitOfWork, IBloodTestRepository, BLLAppDTO.BloodTest, DALAppDTO.BloodTest>, IBloodTestService
    {
        public BloodTestService(IAppUnitOfWork serviceUow, IBloodTestRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new BloodTestMapper(mapper))
        {
        }

        public async Task<IEnumerable<BLLAppDTO.BloodTest>> GetAllTodayAndAllowedAndIncludePersonAsync(Guid userId, bool noTracking = true)
        {
            return (await ServiceRepository.GetAllTodayAndAllowedAndIncludePersonAsync(userId, noTracking)).Select(x => Mapper.Map(x))!;
        }

        public async Task<IEnumerable<BLLAppDTO.BloodTest>> GetAllByPatientId(Guid? personId)
        {
            return (await ServiceRepository.GetAllByPatientId(personId)).Select(x => Mapper.Map(x))!;
        }
    }
}