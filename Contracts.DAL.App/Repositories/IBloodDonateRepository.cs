using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.DAL.Base.Repositories;
using BloodDonate = DAL.App.DTO.BloodDonate;

namespace Contracts.DAL.App.Repositories
{
    public interface IBloodDonateRepository : IBaseRepository<BloodDonate>, IBloodDonateRepositoryCustom<BloodDonate>
    {
        bool CanTransfuseBlood(Guid userId, double amount, Guid? bloodGroupId, bool noTracking);

        IEnumerable<BloodDonate> GetAllAvailableSpecificBloodGroup(Guid? bloodGroupId);
        Task<IEnumerable<BloodDonate>> GetAllIncludingBloodAsync();
        Task<IEnumerable<BloodDonate>> GetLastIndexDayAsync(int days);
        Task<IEnumerable<BloodDonate>> GetAllByPatientId(Guid personId);
        Task<DateTime?> GetLastDonateByPersonId(Guid personId);
    }
    
    public interface IBloodDonateRepositoryCustom<TEntity>
    {

    }
}