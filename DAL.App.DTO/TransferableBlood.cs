using System;
using Domain.Base;

namespace DAL.App.DTO
{
    public class TransferableBlood: DomainEntityMetaId
    {
        public double Amount { get; set; }
        
        public Guid? BloodDonateId { get; set; }
        public DAL.App.DTO.BloodDonate? BloodDonate { get; set; }
        
        public Guid? BloodTransfusionId { get; set; }
        public DAL.App.DTO.BloodTransfusion? BloodTransfusion { get; set; }
        
    }
}