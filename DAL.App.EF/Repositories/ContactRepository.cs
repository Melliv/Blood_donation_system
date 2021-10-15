using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DAL.App.Repositories;
using Contracts.Domain.Base;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain.App;
using Domain.Base;
using Microsoft.EntityFrameworkCore;
using Contact = DAL.App.DTO.Contact;

namespace DAL.App.EF.Repositories
{
    public class ContactRepository : BaseRepository<DAL.App.DTO.Contact, Domain.App.Contact, AppDbContext>, IContactRepository
    {
        public ContactRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new ContactMapper(mapper))
        {
        }
        
        // public override DAL.App.DTO.Contact Remove(Contact contact, Guid userId = default)
        // {
        //     
        //     var contactDomain = Mapper.Map(contact)!;
        //
        //     if (contactDomain.ContactValueId != default) RemoveLangStringsTranslations(contactDomain.ContactValueId);
        //     
        //     return Mapper.Map(RepoDbSet.Remove(contactDomain).Entity)!;;
        // }
        //
        // private void RemoveLangStringsTranslations(Guid entityId)
        // {
        //     var repoDbSetLangStrings = RepoDbContext.Set<LangString>();
        //     var repoDbSetTranslation = RepoDbContext.Set<Translation>();
        //
        //     var resLang = repoDbSetLangStrings.FirstOrDefault(x => x.Id == entityId);
        //     repoDbSetLangStrings.Remove(resLang!);
        //     
        //     var resTrans = repoDbSetTranslation.Where(x => x.LangStringId == entityId).ToList();
        //     foreach (var trans in resTrans)
        //     {
        //         repoDbSetTranslation.Remove(trans);
        //     }
        // }


        public override Contact Update(Contact entity)
        {
            var domainEntity = Mapper.Map(entity);
            
            // load the translations (will loose the dal mapper translations)
            if (entity.ContactValue != null)
            {
                domainEntity!.ContactValue = 
                    RepoDbContext.LangStrings
                        .Include(t => t.Translations)
                        .First(x => x.Id == domainEntity.ContactValueId);
                // set the value from dal entity back to list
                domainEntity!.ContactValue.SetTranslation(entity.ContactValue);
            }

            var updatedEntity = RepoDbSet.Update(domainEntity!).Entity;
            var dalEntity = Mapper.Map(updatedEntity);
            return dalEntity!;
        }

        public override async Task<IEnumerable<DAL.App.DTO.Contact>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            query = query
                .Include(p => p.Person)
                .Include(p => p.ContactType)
                .ThenInclude(x => x!.ContactTypeValue)
                .ThenInclude(z => z!.Translations)
                .Include(x => x.ContactValue)
                .ThenInclude(z => z!.Translations);

            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();


            return res!;
        }
        
        
        public override async Task<DAL.App.DTO.Contact?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            query = query
                .Include(p => p.Person)
                .Include(c => c.ContactType)
                .ThenInclude(x => x!.ContactTypeValue)
                .ThenInclude(z => z!.Translations)
                .Include(x => x.ContactValue)
                .ThenInclude(z => z!.Translations);
                
            var res = await query.FirstOrDefaultAsync(m => m.Id == id);

            return Mapper.Map(res);
        }

        public async Task<IEnumerable<DAL.App.DTO.Contact>> GetAllSpecificPersonAsync(Guid personalId)
        {
            var query = CreateQuery();

            query = query
                .Where(p => p.PersonId == personalId)
                .Include(p => p.Person)
                .Include(c => c.ContactType)
                .ThenInclude(x => x!.ContactTypeValue)
                .ThenInclude(z => z!.Translations)
                .Include(x => x.ContactValue)
                .ThenInclude(z => z!.Translations);
            
            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();
            
            return res!;
        }
    }
}