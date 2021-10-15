using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IPersonTypeRepository : IBaseRepository<PersonType>, IPersonTypeRepositoryCustom<PersonType>
    {
        
    }
    
    public interface IPersonTypeRepositoryCustom<TEntity>
    {
        
    }
}