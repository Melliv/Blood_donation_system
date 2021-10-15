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
using BloodTest = DAL.App.DTO.BloodTest;

namespace DAL.App.EF.Repositories
{
    public class BloodTestRepository : BaseRepository<DAL.App.DTO.BloodTest, Domain.App.BloodTest, AppDbContext>, IBloodTestRepository
    {
        public BloodTestRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new BloodTestMapper(mapper))
        {
        }
        

        public override async Task<BloodTest?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = await query
                .Where(b => b.Id == id)
                .Include(b => b.Donor)
                .Include(b => b.Doctor)
                .Include(b => b.BloodGroup)
                .FirstOrDefaultAsync();

            return Mapper.Map(resQuery)!;
        }


        public override async Task<IEnumerable<BloodTest>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(b => b.Donor)
                .Include(b => b.Doctor)
                .Include(b => b.BloodGroup)
                .OrderBy(x => x.CreateAt);

            var res = await resQuery.Select(x => Mapper.Map(x)).ToListAsync();
            return res!;
        }

        public async Task<IEnumerable<DAL.App.DTO.BloodTest>> GetAllTodayAndAllowedAndIncludePersonAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Where(b => b.Allowed && b.CreateAt >= DateTime.Now.AddDays(-1))
                .Include(b => b.Donor)
                .Include(b => b.Doctor)
                .OrderBy(x => x.CreateAt);

            var res = await resQuery.Select(x => Mapper.Map(x)).ToListAsync();
            return res!;
        }

        public async Task<IEnumerable<BloodTest>> GetAllByPatientId(Guid? personId)
        {
            var query = CreateQuery();
            var resQuery = query
                .Where(p => p.DonorId == personId)
                .Include(b => b.Donor)
                .Include(b => b.Doctor)
                .Include(b => b.BloodGroup)
                .OrderBy(x => x.CreateAt);

            var res = await resQuery.Select(x => Mapper.Map(x)).ToListAsync();
            return res!;
        }
    }
}
