using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace DTO.App.V1
{
    public class Contact : DomainEntityMetaId
    {
        public Guid ContactValueId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Contact), Name = nameof(ContactValue))]
        [MaxLength(128)] public string ContactValue  { get; set; } = default!;
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Contact), Name = nameof(ContactTypeId))]
        public Guid? ContactTypeId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Contact), Name = nameof(ContactType))]
        public ContactType? ContactType { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Contact), Name = nameof(PersonId))]
        public Guid? PersonId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Contact), Name = nameof(Person))]
        public Person? Person { get; set; }
    }
}