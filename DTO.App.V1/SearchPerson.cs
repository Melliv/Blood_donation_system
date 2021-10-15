using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DTO.App.V1
{
    public class SearchPerson : DomainEntityMetaId
    {
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Person), Name = nameof(Firstname))]
        [MaxLength(128)] public string? Firstname { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Person), Name = nameof(Lastname))]
        [MaxLength(128)] public string? Lastname { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Person), Name = nameof(IdentificationCode))]
        [MaxLength(128)] public string? IdentificationCode { get; set; }
    }
}