using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;


namespace DTO.App.V1
{
    public class BloodDonate : DomainEntityMetaId
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodDonate), Name = nameof(DonorId))]
        public Guid DonorId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodDonate), Name = nameof(Donor))]
        public Person? Donor { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodDonate), Name = nameof(DoctorId))]
        public Guid DoctorId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodDonate), Name = nameof(Doctor))]
        public Person? Doctor { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodDonate), Name = nameof(BloodTestId))]
        public Guid? BloodTestId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodDonate), Name = nameof(BloodTestId))]
        public BloodTest? BloodTest { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodDonate), Name = nameof(BloodGroupId))]
        public Guid BloodGroupId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodDonate), Name = nameof(BloodGroup))]
        public BloodGroup? BloodGroup { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "ErrorMessage_Required")]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodDonate), Name = nameof(Amount))]
        public double Amount { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodDonate), Name = nameof(Available))]
        public bool Available { get; set; } = true;
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.BloodDonate), Name = nameof(ExpireDate))]
        public DateTime ExpireDate { get; set; } = DateTime.Now.AddMonths(6);
    }
}