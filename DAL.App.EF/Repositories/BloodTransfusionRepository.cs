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
using BloodTransfusion = DAL.App.DTO.BloodTransfusion;

namespace DAL.App.EF.Repositories
{
    public class BloodTransfusionRepository :
        BaseRepository<DAL.App.DTO.BloodTransfusion, Domain.App.BloodTransfusion, AppDbContext>,
        IBloodTransfusionRepository
    {
        public BloodTransfusionRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new BloodTransfusionMapper(mapper))
        {
        }

        public override async Task<IEnumerable<BloodTransfusion>> GetAllAsync(Guid userId = default,
            bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(b => b.Donor)
                .Include(b => b.Doctor)
                .Include(b => b.BloodGroup);

            var res = await resQuery.Select(x => Mapper.Map(x)).ToListAsync();

            return res!;
        }

        public override async Task<BloodTransfusion?> FirstOrDefaultAsync(Guid id, Guid userId = default,
            bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Where(b => b.Id == id)
                .Include(b => b.Donor)
                .Include(b => b.Doctor)
                .Include(b => b.BloodGroup);

            var res = await resQuery.Select(x => Mapper.Map(x)).FirstOrDefaultAsync();

            return res!;
        }

        public async Task<IEnumerable<BloodTransfusion>> GetLastIndexDayAsync(int days)
        {
            var query = CreateQuery();
            var resQuery = query
                .Where(b => b.CreateAt > DateTime.Now.AddDays(-days))
                .OrderBy(b => b.CreateAt);

            var res = await resQuery.Select(x => Mapper.Map(x)).ToListAsync();

            return res!;
        }

        public async Task<IEnumerable<BloodTransfusion>> GetAllIncludingBloodAsync()
        {
            var query = CreateQuery();
            var resQuery = query
                .Include(b => b!.BloodGroup);

            var res = await resQuery.Select(x => Mapper.Map(x)).ToListAsync();

            return res!;
        }

        public async Task<IEnumerable<BloodTransfusion>> GetAllByPatientId(Guid? personId)
        {
            var query = CreateQuery();
            var resQuery = query
                .Where(b => b.DonorId == personId)
                .Include(b => b.Donor)
                .Include(b => b.Doctor)
                .Include(b => b.BloodGroup);

            var res = await resQuery.Select(x => Mapper.Map(x)).ToListAsync();

            return res!;
        }
    }
}