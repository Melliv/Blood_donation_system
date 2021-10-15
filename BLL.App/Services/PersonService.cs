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
    public class PersonService: BaseEntityService<IAppUnitOfWork, IPersonRepository, BLLAppDTO.Person, DALAppDTO.Person>, IPersonService
    {

        public PersonService(IAppUnitOfWork serviceUow, IPersonRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new PersonMapper(mapper) )
        {
        }
        

        public async Task<IEnumerable<BLLAppDTO.Person>> GetAllSpecificsPersonsAsync(BLLAppDTO.Person person)
        {
            return (await ServiceRepository.GetAllSpecificsPersonsAsync(person)).Select(x => Mapper.Map(x))!;
        }

        public async Task<IEnumerable<BLLAppDTO.Person>> GetAllSpecificPersonsByPersonTypeAsync(string personType)
        {
            return (await ServiceRepository.GetAllSpecificPersonsByPersonTypeAsync(personType)).Select(x => Mapper.Map(x))!;
        }

        public async Task<Guid?> GetBloodGroupIdBySpecificPersonAsync(Guid bloodDonateDonorId)
        {
            return (await ServiceRepository.GetBloodGroupIdBySpecificPersonAsync(bloodDonateDonorId));
        }

        public async Task<BLLAppDTO.Person?> FirstWidthIncludeAsync(Guid id)
        {
            return Mapper.Map(await ServiceRepository.FirstWidthIncludeAsync(id));
        }

        public async Task<int> PutBloodGroupIfNeeded(Guid id, Guid bloodGroupId)
        {
            var person = await ServiceRepository.FirstOrDefaultAsync(id);
            if (person!.BloodGroupId == null)
            {
                person!.BloodGroupId = bloodGroupId;
                ServiceUow.Person.Update(person);
            }
            return await ServiceUow.SaveChangesAsync();
        }
        
    }
}