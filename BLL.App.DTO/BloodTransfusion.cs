using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;
using Person = BLL.App.DTO.Person;
using TransferableBlood = BLL.App.DTO.TransferableBlood;

namespace BLL.App.DTO
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
        public BLL.App.DTO.BloodGroup? BloodGroup { get; set; }
        
        public ICollection<TransferableBlood>? TransferableBlood { get; set; }
    }
}