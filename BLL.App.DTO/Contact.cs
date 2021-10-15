using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;
using ContactType = BLL.App.DTO.ContactType;
using Person = BLL.App.DTO.Person;

namespace BLL.App.DTO
{
    public class Contact: DomainEntityMetaId
    {
        public Guid ContactValueId { get; set; }
        [MaxLength(128)] public string ContactValue  { get; set; } = default!;
        
        public Guid? ContactTypeId { get; set; }
        public ContactType? ContactType { get; set; }
        
        public Guid PersonId { get; set; }
        public Person? Person { get; set; }
    }
}