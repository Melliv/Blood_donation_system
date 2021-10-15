using System;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IBloodGroupRepository : IBaseRepository<BloodGroup>, IBloodGroupRepositoryCustom<BloodGroup>
    {
    }
    
    public interface IBloodGroupRepositoryCustom<TEntity>
    {
        
    }
}