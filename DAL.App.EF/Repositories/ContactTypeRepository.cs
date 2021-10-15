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
using ContactType = DAL.App.DTO.ContactType;

namespace DAL.App.EF.Repositories
{
    public class ContactTypeRepository : BaseRepository<DAL.App.DTO.ContactType, Domain.App.ContactType, AppDbContext>, IContactTypeRepository
    {
        public ContactTypeRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new ContactTypeMapper(mapper))
        {
        }
        public override async Task<IEnumerable<ContactType>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            query = query
                .Include(x => x.ContactTypeValue)
                .ThenInclude(z => z!.Translations);

            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();
            
            return res!;
        }

        public override async Task<ContactType?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            query = query
                .Where(c => c.Id == id)
                .Include(x => x.ContactTypeValue)
                .ThenInclude(z => z!.Translations);

            var res = await query.Select(x => Mapper.Map(x)).FirstOrDefaultAsync();
            
            return res!;
        }
    }
}