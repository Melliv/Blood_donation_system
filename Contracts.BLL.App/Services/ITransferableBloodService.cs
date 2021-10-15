using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface ITransferableBloodService: IBaseEntityService<BLLAppDTO.TransferableBlood, DALAppDTO.TransferableBlood>, ITransferableBloodRepositoryCustom<BLLAppDTO.TransferableBlood>
    {
        void AddFixedAmount(double amount, Guid? bloodGroupId, Guid bloodTransfusionId);
        Task<IEnumerable<BLLAppDTO.TransferableBlood>> GetAllByTransfusionIdAsync(Guid transfusionId);
    }
}