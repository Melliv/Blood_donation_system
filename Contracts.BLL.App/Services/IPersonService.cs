using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using DTO.App.V1;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IPersonService: IBaseEntityService<BLLAppDTO.Person, DALAppDTO.Person>, IPersonRepositoryCustom<BLLAppDTO.Person>
    {
        new Task<IEnumerable<BLLAppDTO.Person>> GetAllSpecificsPersonsAsync(BLLAppDTO.Person person);
        new Task<IEnumerable<BLLAppDTO.Person>> GetAllSpecificPersonsByPersonTypeAsync(string personType);
        Task<Guid?> GetBloodGroupIdBySpecificPersonAsync(Guid bloodDonateDonorId);
        new Task<BLLAppDTO.Person?> FirstWidthIncludeAsync(Guid id);
        Task<int> PutBloodGroupIfNeeded(Guid id, Guid bloodGroupId);
    }
}