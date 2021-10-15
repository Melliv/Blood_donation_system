using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace DTO.App.V1
{
    public class ContactType : DomainEntityMetaId
    {
        
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.ContactType), Name = nameof(ContactTypeValue))]
        [MaxLength(128)] public string ContactTypeValue  { get; set; } = default!;
    }
}