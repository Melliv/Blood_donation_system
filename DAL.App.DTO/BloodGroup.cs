using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.App;
using Domain.Base;

namespace DAL.App.DTO
{
    public class BloodGroup: DomainEntityMetaId
    {
        [MaxLength(128)] public string BloodGroupValue { get; set; } = default!;
        
        [InverseProperty(nameof(BloodDonate.BloodGroup))]
        public ICollection<DAL.App.DTO.BloodDonate>? BloodTypes { get; set; }
        
        [InverseProperty(nameof(BloodTransfusion.BloodGroup))]
        public ICollection<BloodTransfusion>? BloodTransfusionBloodTypes { get; set; }
        
        [InverseProperty(nameof(Person.BloodGroup))]
        public ICollection<Person>? PersonBloodTypes { get; set; }
        
        [InverseProperty(nameof(BloodTest.BloodGroup))]
        public ICollection<BloodTest>? BloodTestBloodTypes { get; set; }

    }
}