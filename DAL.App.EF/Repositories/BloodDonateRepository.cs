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
using BloodDonate = DAL.App.DTO.BloodDonate;
using Person = BLL.App.DTO.Person;

namespace DAL.App.EF.Repositories
{
    public class BloodDonateRepository : BaseRepository<DAL.App.DTO.BloodDonate, Domain.App.BloodDonate, AppDbContext>, IBloodDonateRepository
    {
        public BloodDonateRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new BloodDonateMapper(mapper))
        {
        }

        public async Task<IEnumerable<DAL.App.DTO.BloodDonate>> GetAllIncludingBloodAsync()
        {
            var query = CreateQuery();
            var resQuery = query
                .Include(b => b!.BloodGroup);

            var res = await resQuery.Select(x => Mapper.Map(x)).ToListAsync();

            return res!;
        }

        public async Task<IEnumerable<BloodDonate>> GetLastIndexDayAsync(int days)
        {
            var query = CreateQuery();
            var resQuery = query
                .Where(b => b.CreateAt > DateTime.Now.AddDays(-days))
                .OrderBy(b => b.CreateAt);

            var res = await resQuery.Select(x => Mapper.Map(x)).ToListAsync();

            return res!;
        }

        public async Task<IEnumerable<BloodDonate>> GetAllByPatientId(Guid personId)
        {
            var query = CreateQuery();
            var resQuery = query
                .Where(b => b.DonorId == personId)
                .Include(b => b.Donor)
                .Include(b => b.Doctor)
                .Include(b => b.BloodGroup)
                .Include(b => b.BloodTest);

            var res = await resQuery.Select(x => Mapper.Map(x)).ToListAsync();

            return res!;
        }

        public async Task<DateTime?> GetLastDonateByPersonId(Guid personId)
        {
            var query = CreateQuery();
            var resQuery = await query
                .Where(b => b.DonorId == personId)
                .OrderBy(b => b.CreateAt)
                .LastOrDefaultAsync();

            return resQuery?.CreateAt;
        }


        public bool CanTransfuseBlood(Guid userId, double amount, Guid? bloodGroupId, bool noTracking)
        {
            var query = CreateQuery(userId, noTracking);
            var stockAmount = query
                .Where(b => b.BloodGroupId == bloodGroupId && b.Available)
                .Sum(b => b.Amount);

            return  stockAmount >= amount ;
        }

        public IEnumerable<BloodDonate> GetAllAvailableSpecificBloodGroup(Guid? bloodGroupId)
        {
            var query = CreateQuery();
            return query.Where(b => b.Available && b.BloodGroupId == bloodGroupId).Select(b => Mapper.Map(b))!;
        }

        public override async Task<BloodDonate?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Where(b => b.Id == id)
                .Include(b => b.BloodGroup)
                .Include(b => b.Doctor)
                .Include(b => b.Donor)
                .Include(b => b.BloodTest);
            
            var res = await resQuery.Select(x => Mapper.Map(x)).FirstOrDefaultAsync();

            return res!;
        }

        public override async Task<IEnumerable<BloodDonate>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(b => b.Donor)
                .Include(b => b.Doctor)
                .Include(b => b.BloodGroup)
                .Include(b => b.BloodTest);

            var res = await resQuery.Select(x => Mapper.Map(x)).ToListAsync();

            return res!;
        }
        
    }
}