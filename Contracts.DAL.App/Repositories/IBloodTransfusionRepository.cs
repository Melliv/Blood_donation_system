using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IBloodTransfusionRepository : IBaseRepository<BloodTransfusion>, IBloodTransfusionCustom<BloodTransfusion>
    {
        Task<IEnumerable<BloodTransfusion>> GetLastIndexDayAsync(int days);
        Task<IEnumerable<BloodTransfusion>> GetAllIncludingBloodAsync();
        Task<IEnumerable<BloodTransfusion>> GetAllByPatientId(Guid? personId);
    }
    
    public interface IBloodTransfusionCustom<TEntity>
    {
        
    }
}