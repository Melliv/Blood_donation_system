using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IBloodTestRepository : IBaseRepository<BloodTest>, IBloodTestRepositoryCustom<BloodTest>
    {
        Task<IEnumerable<BloodTest>> GetAllByPatientId(Guid? personId);
    }
    
    public interface IBloodTestRepositoryCustom<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllTodayAndAllowedAndIncludePersonAsync(Guid userId, bool noTracking = true);
    }
}
