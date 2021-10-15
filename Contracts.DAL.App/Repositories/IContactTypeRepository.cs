using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IContactTypeRepository : IBaseRepository<ContactType>, IContactTypeRepositoryCustom<ContactType>
    {
        
    }
    
    public interface IContactTypeRepositoryCustom<TEntity>
    {
        
    }
}