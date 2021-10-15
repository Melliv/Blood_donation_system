using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.App
{
    public class BloodTest: DomainEntityMetaId
    {
        public bool Allowed { get; set; }
        [MaxLength(1024)] public string? Comments { get; set; }
        
        public Guid? DonorId { get; set; }
        public Person? Donor { get; set; }
        
        public Guid? DoctorId { get; set; }
        public Person? Doctor { get; set; }
        
        public Guid? BloodGroupId { get; set; }
        public BloodGroup? BloodGroup { get; set; }
        
        public ICollection<BloodDonate>? BloodDonates { get; set; }
    }
}