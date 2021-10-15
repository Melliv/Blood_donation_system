using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.App
{
    public class ContactType: DomainEntityMetaId
    {
        public Guid ContactTypeValueId { get; set; } 
        [MaxLength(128)] public LangString? ContactTypeValue { get; set; }
        
        [InverseProperty(nameof(Contact.ContactType))]
        public ICollection<Contact>? Contacts { get; set; }
    }
}