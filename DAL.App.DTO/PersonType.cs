using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace DAL.App.DTO
{
    public class PersonType: DomainEntityMetaId
    {
        public Guid PersonTypeValueId { get; set; }
        [MaxLength(128)] public string PersonTypeValue { get; set; } = default!;
        
        public Guid SecondaryPersonTypeValueId { get; set; }
        [MaxLength(128)] public string SecondaryPersonTypeValue { get; set; } = default!;
        
        [InverseProperty(nameof(Person.PersonType))]
        public ICollection<DAL.App.DTO.Person>? People { get; set; }
    }
}