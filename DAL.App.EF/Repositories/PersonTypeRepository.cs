using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain.App;
using Microsoft.EntityFrameworkCore;
using PersonType = DAL.App.DTO.PersonType;

namespace DAL.App.EF.Repositories
{
    public class PersonTypeRepository : BaseRepository<DAL.App.DTO.PersonType, Domain.App.PersonType, AppDbContext>, IPersonTypeRepository
    {
        public PersonTypeRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new PersonTypeMapper(mapper))
        {
        }

        public override async Task<IEnumerable<PersonType>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            
            query = query
                .Include(x => x.PersonTypeValue)
                    .ThenInclude(z => z!.Translations)
                .Include(x => x.SecondaryPersonTypeValue)
                    .ThenInclude(z => z!.Translations);
            
            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();
            
            return res!;
        }
        
        public override async Task<PersonType?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Where(p => p.Id == id)
                .Include(x => x.PersonTypeValue)
                    .ThenInclude(z => z!.Translations)
                .Include(x => x.SecondaryPersonTypeValue)
                    .ThenInclude(z => z!.Translations);
            
            var res = await resQuery.Select(x => Mapper.Map(x)).FirstOrDefaultAsync();

            return res!;
        }
        
        public override PersonType Update(PersonType entity)
        {
            var domainEntity = Mapper.Map(entity);

            // load the translations (will loose the dal mapper translations)
            domainEntity!.PersonTypeValue = 
                RepoDbContext.LangStrings
                    .Include(t => t.Translations)
                    .First(x => x.Id == domainEntity.PersonTypeValueId);
            
            domainEntity!.SecondaryPersonTypeValue = 
                RepoDbContext.LangStrings
                    .Include(t => t.Translations)
                    .First(x => x.Id == domainEntity.SecondaryPersonTypeValueId);
                    
            // set the value from dal entity back to list
            
            domainEntity!.PersonTypeValue.SetTranslation(entity.PersonTypeValue);
            domainEntity!.SecondaryPersonTypeValue.SetTranslation(entity.SecondaryPersonTypeValue);

            var updatedEntity = RepoDbSet.Update(domainEntity!).Entity;
            var dalEntity = Mapper.Map(updatedEntity);
            return dalEntity!;
        }
    }
}
