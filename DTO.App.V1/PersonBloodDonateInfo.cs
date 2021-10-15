using System;
using System.ComponentModel.DataAnnotations;

namespace DTO.App.V1
{
    public class PersonBloodDonateInfo
    {
        [Display(ResourceType = typeof(Resources.DTO.App.V1.PersonBloodDonateInfo), Name = nameof(Date))]
        public DateTime? Date { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.PersonBloodDonateInfo), Name = nameof(Allowed))]
        public bool Allowed { get; set; }
    }
}