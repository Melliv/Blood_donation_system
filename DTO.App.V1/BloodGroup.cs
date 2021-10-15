using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DTO.App.V1
{
    public class BloodGroup : DomainEntityMetaId
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodGroup), Name = nameof(BloodGroupValue))]
        [MaxLength(36)] public string? BloodGroupValue { get; set; }
    }
}