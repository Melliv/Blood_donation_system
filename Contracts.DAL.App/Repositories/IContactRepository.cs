using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain.App;
using DAL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IContactRepository : IBaseRepository<DALAppDTO.Contact>, IContactRepositoryCustom<DALAppDTO.Contact>
    {
        Task<IEnumerable<DALAppDTO.Contact>> GetAllSpecificPersonAsync(Guid personalId);
    }
    
    public interface IContactRepositoryCustom<TEntity>
    {
        
        
    }
}