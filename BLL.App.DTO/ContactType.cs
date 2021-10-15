using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace BLL.App.DTO
{
    public class ContactType: DomainEntityMetaId
    {
        public Guid ContactTypeValueId { get; set; }
        [MaxLength(128)] public string ContactTypeValue { get; set; } = null!;
        
        [InverseProperty(nameof(BLL.App.DTO.Contact.ContactType))]
        public ICollection<BLL.App.DTO.Contact>? Contacts { get; set; }
    }
}