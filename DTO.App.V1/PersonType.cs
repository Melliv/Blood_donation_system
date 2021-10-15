using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DTO.App.V1
{
    public class PersonType : DomainEntityMetaId
    {
        public Guid PersonTypeValueId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.PersonType), Name = nameof(PersonTypeValue))]
        [MaxLength(128)] public string PersonTypeValue { get; set; } = default!;
        
        public Guid SecondaryPersonTypeValueId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.PersonType), Name = nameof(SecondaryPersonTypeValue))]
        [MaxLength(128)] public string SecondaryPersonTypeValue { get; set; } = default!;
    }
}