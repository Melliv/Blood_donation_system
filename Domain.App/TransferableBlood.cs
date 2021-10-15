using System;
using Domain.Base;

namespace Domain.App
{
    public class TransferableBlood: DomainEntityMetaId
    {
        public double Amount { get; set; }
        
        public Guid? BloodDonateId { get; set; }
        public BloodDonate? BloodDonate { get; set; }
        
        public Guid? BloodTransfusionId { get; set; }
        public BloodTransfusion? BloodTransfusion { get; set; }
        
    }
}