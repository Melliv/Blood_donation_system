using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.App
{
    public class PersonType: DomainEntityMetaId
    {
        public Guid PersonTypeValueId { get; set; }
        [MaxLength(128)] public LangString? PersonTypeValue { get; set; }
        
        public Guid SecondaryPersonTypeValueId { get; set; }
        [MaxLength(128)] public LangString? SecondaryPersonTypeValue { get; set; }
        
        public ICollection<Person>? People { get; set; }
    }
}