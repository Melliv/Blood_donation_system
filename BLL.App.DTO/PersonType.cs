using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace BLL.App.DTO
{
    public class PersonType: DomainEntityMetaId
    {
        public Guid PersonTypeValueId { get; set; }
        [MaxLength(128)] public string PersonTypeValue { get; set; } = default!;
        
        public Guid SecondaryPersonTypeValueId { get; set; }

        [MaxLength(128)] public string SecondaryPersonTypeValue { get; set; } = default!;
        
        public ICollection<BLL.App.DTO.Person>? People { get; set; }
    }
}