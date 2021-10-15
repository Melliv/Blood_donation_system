using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IBloodTestService: IBaseEntityService<BLLAppDTO.BloodTest, DALAppDTO.BloodTest>, IBloodTestRepositoryCustom<BLLAppDTO.BloodTest>
    {
        
        new Task<IEnumerable<BLLAppDTO.BloodTest>> GetAllTodayAndAllowedAndIncludePersonAsync(Guid userId, bool noTracking = true);

        Task<IEnumerable<BLLAppDTO.BloodTest>> GetAllByPatientId(Guid? personId);
    }
}