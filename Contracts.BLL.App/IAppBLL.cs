using System;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base;
using Contracts.BLL.Base.Services;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;
namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        IPersonService Persons { get; }
        IContactService Contacts { get; }
        IContactTypeService ContactTypes { get; }
        IPersonTypeService PersonType { get; }
        IBloodGroupService BloodGroup { get; }
        IBloodTestService BloodTest { get; }
        IBloodTransfusionService BloodTransfusion { get; }
        ITransferableBloodService TransferableBlood { get; }
        IBloodDonateService BloodDonate { get; }

    }
}