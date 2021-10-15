using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class BloodGroupRepository : BaseRepository<DAL.App.DTO.BloodGroup, Domain.App.BloodGroup, AppDbContext>, IBloodGroupRepository
    {
        public BloodGroupRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new BloodGroupMapper(mapper))
        {
        }
        
    }
}