using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface ITransferableBloodRepository : IBaseRepository<TransferableBlood>, ITransferableBloodRepositoryCustom<TransferableBlood>
    {
        Task<IEnumerable<TransferableBlood>> GetAllByTransfusionIdAsync(Guid transfusionId);
    }
    
    public interface ITransferableBloodRepositoryCustom<TEntity>
    {
        
    }
}