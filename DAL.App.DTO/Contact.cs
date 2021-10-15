using System;
using System.ComponentModel.DataAnnotations;
using Domain.App;
using Domain.Base;

namespace DAL.App.DTO
{
    public class Contact: DomainEntityMetaId
    {
        public Guid? ContactValueId { get; set; }
        [MaxLength(128)] public string? ContactValue  { get; set; }
        
        public Guid? ContactTypeId { get; set; }
        public ContactType? ContactType { get; set; }
        
        public Guid PersonId { get; set; }
        public Person? Person { get; set; }
    }
}