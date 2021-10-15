using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DTO.App.V1
{
    public class BloodTest : DomainEntityMetaId
    {
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodTest), Name = nameof(Allowed))]
        public bool Allowed { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodTest), Name = nameof(Comments))]
        [MaxLength(1024)]
        public string? Comments { get; set; } = "";
        
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodTest), Name = nameof(DonorId))]
        public Guid DonorId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodTest), Name = nameof(Donor))]
        public Person? Donor { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodTest), Name = nameof(DoctorId))]
        public Guid DoctorId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodTest), Name = nameof(Doctor))]
        public Person? Doctor { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodTest), Name = nameof(BloodGroupId))]
        public Guid BloodGroupId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodTest), Name = nameof(BloodGroup))]
        public BloodGroup? BloodGroup { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodTest), Name = nameof(OverviewData))]
        public string OverviewData { get; set; } = "-";
    }
}