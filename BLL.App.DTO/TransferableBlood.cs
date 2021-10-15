using System;
using Domain.Base;

namespace BLL.App.DTO
{
    public class TransferableBlood: DomainEntityMetaId
    {
        public double Amount { get; set; }
        
        public Guid? BloodDonateId { get; set; }
        public BLL.App.DTO.BloodDonate? BloodDonate { get; set; }
        
        public Guid? BloodTransfusionId { get; set; }
        public BLL.App.DTO.BloodTransfusion? BloodTransfusion { get; set; }
        
    }
}