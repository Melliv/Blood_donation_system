using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.App;
using Domain.Base;

namespace DAL.App.DTO
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
        
        [InverseProperty(nameof(BloodDonate.BloodTest))]
        public ICollection<DAL.App.DTO.BloodDonate>? BloodDonates { get; set; }
    }
}