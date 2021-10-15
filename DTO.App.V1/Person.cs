using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DTO.App.V1
{
    public class Person : DomainEntityMetaId
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Person), Name = nameof(Firstname))]
        [MaxLength(128)] public string Firstname { get; set; } = default!;
        
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Person), Name = nameof(Lastname))]
        [MaxLength(128)] public string Lastname { get; set; } = default!;
        
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Person), Name = nameof(IdentificationCode))]
        [MaxLength(128)] public string IdentificationCode { get; set; } = default!;
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Person), Name = nameof(Comments))]
        [MaxLength(1024)]
        public string? Comments { get; set; } = "";
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Person), Name = nameof(PersonTypeId))]
        
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        public Guid PersonTypeId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Person), Name = nameof(PersonType))]
        public PersonType? PersonType { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Person), Name = nameof(BloodGroupId))]
        public Guid? BloodGroupId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Person), Name = nameof(BloodGroup))]
        public BloodGroup? BloodGroup { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Person), Name = nameof(FullName))]
        public string FullName => Firstname + " " + Lastname;

    }
}