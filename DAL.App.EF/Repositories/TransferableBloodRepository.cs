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
using TransferableBlood = DAL.App.DTO.TransferableBlood;

namespace DAL.App.EF.Repositories
{
    public class TransferableBloodRepository : BaseRepository<DAL.App.DTO.TransferableBlood, Domain.App.TransferableBlood, AppDbContext>, ITransferableBloodRepository
    {
        public TransferableBloodRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new TransferableBloodMapper(mapper))
        {
        }

        public async Task<IEnumerable<TransferableBlood>> GetAllByTransfusionIdAsync(Guid transfusionId)
        {
            var query = CreateQuery();
            var resQuery = query
                .Where(t => t.BloodTransfusionId == transfusionId)
                .Include(t => t.BloodDonate)
                .ThenInclude(b => b!.Donor);

            var res = await resQuery.Select(x => Mapper.Map(x)).ToListAsync();

            return res!;
        }
    }
}