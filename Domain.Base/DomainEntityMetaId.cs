using System;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain.Base;

namespace Domain.Base
{
    public class DomainEntityMetaId: DomainEntityMetaId<Guid>, IDomainEntityId
    {
        
    }

    public class DomainEntityMetaId<TKey>: DomainEntityId<TKey> , IDomainEntityMeta
        where TKey : IEquatable<TKey>
    {
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Overall), Name = nameof(CreatedBy))]
        [MaxLength(128)]
        public string CreatedBy { get; set; } = "-";
        
        [DataType(DataType.Date)]
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Overall), Name = nameof(CreateAt))]
        public DateTime CreateAt { get; set; }
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Overall), Name = nameof(UpdateBy))]
        [MaxLength(128)]
        public string UpdateBy { get; set; } = "-";
        
        [Display(ResourceType = typeof(Resources.DTO.App.V1.Overall), Name = nameof(UpdatedAt))]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}