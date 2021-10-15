using System;
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
    public class BloodGroupService: BaseEntityService<IAppUnitOfWork, IBloodGroupRepository, BLLAppDTO.BloodGroup, DALAppDTO.BloodGroup>, IBloodGroupService
    {
        public BloodGroupService(IAppUnitOfWork serviceUow, IBloodGroupRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new BloodGroupMapper(mapper))
        {
        }
        
    }
}