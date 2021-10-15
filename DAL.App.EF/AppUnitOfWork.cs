using AutoMapper;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF;
using Domain.App;

namespace DAL.App.EF
{
    public class AppUnitOfWork : BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        protected IMapper Mapper;
        public AppUnitOfWork(AppDbContext uowDbContext, IMapper mapper) : base(uowDbContext)
        {
            Mapper = mapper;
        }

        public IPersonRepository Person =>
            GetRepository((() => new PersonRepository(UowDbContext, Mapper)));
        public IBloodDonateRepository BloodDonate  =>
            GetRepository((() => new BloodDonateRepository(UowDbContext, Mapper)));
        public IBloodGroupRepository BloodGroup  =>
            GetRepository((() => new BloodGroupRepository(UowDbContext, Mapper)));
        public IBloodTestRepository BloodTest  =>
            GetRepository((() => new BloodTestRepository(UowDbContext, Mapper)));
        public IBloodTransfusionRepository BloodTransfusion  =>
            GetRepository((() => new BloodTransfusionRepository(UowDbContext, Mapper)));
        public IContactRepository Contact  =>
            GetRepository((() => new ContactRepository(UowDbContext, Mapper)));
        public IContactTypeRepository ContactType  =>
            GetRepository((() => new ContactTypeRepository(UowDbContext, Mapper)));
        public IPersonTypeRepository PersonType  =>
            GetRepository((() => new PersonTypeRepository(UowDbContext, Mapper)));
        public ITransferableBloodRepository TransferableBlood  =>
            GetRepository((() => new TransferableBloodRepository(UowDbContext, Mapper)));
    }
}