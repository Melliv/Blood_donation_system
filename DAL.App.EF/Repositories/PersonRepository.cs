using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using DTO.App.V1;
using Microsoft.EntityFrameworkCore;
using Person = DAL.App.DTO.Person;

namespace DAL.App.EF.Repositories
{
    public class PersonRepository : BaseRepository<DAL.App.DTO.Person, Domain.App.Person, AppDbContext>, IPersonRepository
    {
        public PersonRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new PersonMapper(mapper))
        {
        }

        public async Task<DAL.App.DTO.Person?> FirstWidthIncludeAsync(Guid id)
        {
            var query = CreateQuery();
            var resQuery = query
                .Where(p => p.Id == id)
                .Include(p => p.BloodGroup)
                .Include(p => p.PersonType)
                .ThenInclude(z => z!.PersonTypeValue)
                .ThenInclude(z => z!.Translations);

            var res = await resQuery.Select(x => Mapper.Map(x)).FirstOrDefaultAsync();

            return res;
        }

        public override async Task<IEnumerable<Person>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(p => p.BloodGroup)
                .Include(p => p.PersonType);

            var res = await resQuery.Select(domainEntity => Mapper.Map(domainEntity)).ToListAsync();

            return res!;
        }

        public async Task<IEnumerable<DAL.App.DTO.Person>> GetAllSpecificsPersonsAsync(BLL.App.DTO.Person person)
        {
            var query = CreateQuery();
            
            if (!string.IsNullOrWhiteSpace(person.Firstname))
                query = query.Where(p =>  p.Firstname.ToLower() == person.Firstname.ToLower());
            
            if (!string.IsNullOrWhiteSpace(person.Lastname))
                query = query.Where(p =>  p.Lastname.ToLower() == person.Lastname.ToLower());
            
            if (!string.IsNullOrWhiteSpace(person.IdentificationCode))
                query = query.Where(p =>  p.IdentificationCode == person.IdentificationCode);
            
            var resQuery = query
                .Include(p => p.PersonType)
                .ThenInclude(z => z!.PersonTypeValue)
                .ThenInclude(z => z!.Translations)
                .Include(p => p.BloodGroup)
                .Take(50)
                .OrderBy(x => x.Lastname)
                .ThenBy(x => x.Firstname);

            var res = await resQuery.Select(x => Mapper.Map(x)).ToListAsync();
            return res!;
        }

        public async Task<Guid?> GetBloodGroupIdBySpecificPersonAsync(Guid bloodDonateDonorId)
        {
            var query = CreateQuery();
            var res = await query
                .Where(p => p.Id == bloodDonateDonorId)
                .Select(p => p.BloodGroupId)
                .FirstOrDefaultAsync();
            return res;
        }

        public async Task<IEnumerable<DAL.App.DTO.Person>> GetAllSpecificPersonsByPersonTypeAsync(string personType)
        {
            var query = CreateQuery();
            var resQuery = query
                .Where(p => p.PersonType != null && p.PersonType.PersonTypeValue!.Translations!
                    .Any(x => x.Value == personType))
                .Take(50)
                .OrderBy(x => x.Lastname)
                .ThenBy(x => x.Firstname);

            var res = await resQuery.Select(x => Mapper.Map(x)).ToListAsync();

            return res!;
        }
    }
}



