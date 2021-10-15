using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        IPersonRepository Person { get; }
        IBloodDonateRepository BloodDonate { get; }
        IBloodGroupRepository BloodGroup { get; }
        IBloodTestRepository BloodTest { get; }
        IBloodTransfusionRepository BloodTransfusion { get; }
        IContactRepository Contact { get; }
        IContactTypeRepository ContactType { get; }
        IPersonTypeRepository PersonType { get; }
        ITransferableBloodRepository TransferableBlood { get; }

    }
}