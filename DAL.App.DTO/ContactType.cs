using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace DAL.App.DTO
{
    public class ContactType: DomainEntityMetaId
    {
        public Guid ContactTypeValueId { get; set; }
        [MaxLength(128)] public string ContactTypeValue { get; set; } = default!;
        
        [InverseProperty(nameof(DAL.App.DTO.Contact.ContactType))]
        public ICollection<DAL.App.DTO.Contact>? Contacts { get; set; }
    }
}