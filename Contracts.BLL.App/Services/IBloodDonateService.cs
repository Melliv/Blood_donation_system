using System;
using System.Collections.Generic;
using Google.DataTable.Net.Wrapper;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using DTO.App.V1;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IBloodDonateService: IBaseEntityService<BLLAppDTO.BloodDonate, DALAppDTO.BloodDonate>, IBloodDonateRepositoryCustom<BLLAppDTO.BloodDonate>
    {
        bool CanTransfuseBlood(Guid userId, double amount, Guid? bloodGroupId, bool noTracking = true);
        Task<DataTable> GetStatistic();
        Task<DataTable> GetStatisticByTime();
        Task<IEnumerable<BLLAppDTO.BloodDonate>> GetAllByPatientId(Guid personId);
        Task<DateTime?> GetLastDonateByPersonId(Guid personId);
    }
}