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
    public class PersonTypeService: BaseEntityService<IAppUnitOfWork, IPersonTypeRepository, BLLAppDTO.PersonType, DALAppDTO.PersonType>, IPersonTypeService
    {
        public PersonTypeService(IAppUnitOfWork serviceUow, IPersonTypeRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new PersonTypeMapper(mapper))
        {
        }
    }
}