using System;
using AutoMapper;
using BLL.App.Mappers;
using BLL.App.Services;
using BLL.Base;
using BLL.Base.Services;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App;
using Contracts.DAL.Base.Repositories;
using Domain.App;

namespace BLL.App
{
    public class AppBLL : BaseBLL<IAppUnitOfWork>, IAppBLL
    {
        protected IMapper Mapper;
        public AppBLL(IAppUnitOfWork uow, IMapper mapper) : base(uow)
        {
            Mapper = mapper;
        }

        public IPersonService Persons =>
            GetService<IPersonService>(() => new PersonService(Uow, Uow.Person, Mapper));

        public IContactService Contacts =>
            GetService<IContactService>(() => new ContactService(Uow, Uow.Contact, Mapper));

        public IContactTypeService ContactTypes =>
            GetService<IContactTypeService>(() => new ContactTypeService(Uow, Uow.ContactType, Mapper));
        
        public IPersonTypeService PersonType =>
            GetService<IPersonTypeService>(() => new PersonTypeService(Uow, Uow.PersonType, Mapper));
        
        public IBloodGroupService BloodGroup =>
            GetService<IBloodGroupService>(() => new BloodGroupService(Uow, Uow.BloodGroup, Mapper));

        public IBloodTestService BloodTest =>
            GetService<IBloodTestService>(() => new BloodTestService(Uow, Uow.BloodTest, Mapper));
        public IBloodTransfusionService BloodTransfusion =>
            GetService<IBloodTransfusionService>(() => new BloodTransfusionService(Uow, Uow.BloodTransfusion, Mapper));
        public ITransferableBloodService TransferableBlood =>
            GetService<ITransferableBloodService>(() => new TransferableBloodService(Uow, Uow.TransferableBlood, Mapper));
        public IBloodDonateService BloodDonate =>
            GetService<IBloodDonateService>(() => new BloodDonateService(Uow, Uow.BloodDonate, Mapper));

    }
}