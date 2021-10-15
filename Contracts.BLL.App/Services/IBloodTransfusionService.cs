using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using Google.DataTable.Net.Wrapper;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IBloodTransfusionService: IBaseEntityService<BLLAppDTO.BloodTransfusion, DALAppDTO.BloodTransfusion>, IBloodTransfusionCustom<BLLAppDTO.BloodTransfusion>
    {
        Task<DataTable> GetStatistic();
        Task<IEnumerable<BLLAppDTO.BloodTransfusion>> GetAllByPatientId(Guid? personId);
    }
}