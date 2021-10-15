using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DTO.App.V1
{
    public class BloodTransfusion : DomainEntityMetaId
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodTransfusion), Name = nameof(Amount))]
        public double Amount { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodTransfusion), Name = nameof(Comments))]
        [MaxLength(1024)]
        public string? Comments { get; set; } = "";
        
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodTransfusion), Name = nameof(DonorId))]
        public Guid? DonorId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodTransfusion), Name = nameof(Donor))]
        public Person? Donor { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodTransfusion), Name = nameof(DoctorId))]
        public Guid? DoctorId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodTransfusion), Name = nameof(Doctor))]
        public Person? Doctor { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodTransfusion), Name = nameof(BloodGroupId))]
        public Guid? BloodGroupId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodTransfusion), Name = nameof(BloodGroup))]
        public BloodGroup? BloodGroup { get; set; }
    }
}