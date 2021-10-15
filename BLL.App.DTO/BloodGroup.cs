using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;
using BloodTransfusion = BLL.App.DTO.BloodTransfusion;
using Person = BLL.App.DTO.Person;

namespace BLL.App.DTO
{
    public class BloodGroup: DomainEntityMetaId
    {
        [MaxLength(128)] public string BloodGroupValue { get; set; } = default!;
        
        public ICollection<BLL.App.DTO.BloodDonate>? BloodTypes { get; set; }
        public ICollection<BloodTransfusion>? BloodTransfusionBloodTypes { get; set; }
        public ICollection<Person>? PersonBloodTypes { get; set; }
        public ICollection<BloodTest>? BloodTestBloodTypes { get; set; }
    }
}