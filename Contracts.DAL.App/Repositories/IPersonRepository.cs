using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DTO.App.V1;
using Person = DAL.App.DTO.Person;

namespace Contracts.DAL.App.Repositories
{
    public interface IPersonRepository : IBaseRepository<Person>, IPersonRepositoryCustom<Person>
    {
        // add your Person custom method declarations here

        Task<Guid?> GetBloodGroupIdBySpecificPersonAsync(Guid bloodDonateDonorId);
    }
    
    public interface IPersonRepositoryCustom<TEntity>
    {
        Task<TEntity?> FirstWidthIncludeAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllSpecificPersonsByPersonTypeAsync(string personType);
        Task<IEnumerable<TEntity>> GetAllSpecificsPersonsAsync(BLL.App.DTO.Person person);
        
        
    }

}