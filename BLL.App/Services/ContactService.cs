using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace BLL.App.Services
{
    public class ContactService: BaseEntityService<IAppUnitOfWork, IContactRepository, BLLAppDTO.Contact, DALAppDTO.Contact>, IContactService
    {
        public ContactService(IAppUnitOfWork serviceUow, IContactRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new ContactMapper(mapper))
        {
        }

        public async Task<IEnumerable<BLLAppDTO.Contact>> GetAllSpecificPersonAsync(Guid personalId)
        {
            return (await ServiceRepository.GetAllSpecificPersonAsync(personalId)).Select(x => Mapper.Map(x))!;
        }
    }
}