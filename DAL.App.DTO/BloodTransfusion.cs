using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.App;
using Domain.Base;

namespace DAL.App.DTO
{
    public class BloodTransfusion: DomainEntityMetaId
    {
        public double Amount { get; set; }
        
        [MaxLength(1024)] public string? Comments { get; set; }
        
        public Guid? DonorId { get; set; }
        public Person? Donor { get; set; }
        
        public Guid? DoctorId { get; set; }
        public Person? Doctor { get; set; }
        
        public Guid? BloodGroupId { get; set; }
        public DAL.App.DTO.BloodGroup? BloodGroup { get; set; }
        
        [InverseProperty(nameof(TransferableBlood.BloodTransfusion))]
        public ICollection<TransferableBlood>? TransferableBloods { get; set; }
    }
}