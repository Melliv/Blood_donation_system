using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.App
{
    public class Contact: DomainEntityMetaId
    {
        [MaxLength(128)]
        public Guid ContactValueId { get; set; }
        public LangString? ContactValue { get; set; }

        public Guid? ContactTypeId { get; set; }
        public ContactType? ContactType { get; set; }
        
        [ForeignKey(nameof(Person))]
        public Guid? PersonId { get; set; }
        public Person? Person { get; set; }
    }
}