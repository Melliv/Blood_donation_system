using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class Person: DomainEntityMetaId
    {
        [MaxLength(128)] public string Firstname { get; set; } = default!;
        [MaxLength(128)] public string Lastname { get; set; } = default!;
        [MaxLength(128)] public string IdentificationCode { get; set; } = default!;
        
        [MaxLength(1024)] public string? Comments { get; set; }

        public Guid? PersonTypeId { get; set; }
        public PersonType? PersonType { get; set; }
        
        public Guid? BloodGroupId { get; set; }
        public BLL.App.DTO.BloodGroup? BloodGroup { get; set; }
        
        [InverseProperty(nameof(Domain.App.BloodTest.Donor))]
        public ICollection<Domain.App.BloodTest>? BloodTestsDonors { get; set; }
        [InverseProperty(nameof(Domain.App.BloodTest.Doctor))]
        public ICollection<Domain.App.BloodTest>? BloodTestsDoctors { get; set; }
        
        [InverseProperty(nameof(Domain.App.BloodDonate.Donor))]
        public ICollection<Domain.App.BloodDonate>? BloodDonateDonors { get; set; }
        [InverseProperty(nameof(Domain.App.BloodDonate.Doctor))]
        public ICollection<Domain.App.BloodDonate>? BloodDonateDoctors { get; set; }
        
        [InverseProperty(nameof(Domain.App.BloodTransfusion.Donor))]
        public ICollection<Domain.App.BloodTransfusion>? BloodTransfusionDonors { get; set; }
        [InverseProperty(nameof(Domain.App.BloodTransfusion.Doctor))]
        public ICollection<Domain.App.BloodTransfusion>? BloodTransfusionDoctors { get; set; }
        
        [InverseProperty(nameof(Contact.Person))]
        public ICollection<Contact>? Contacts { get; set; }
        public string FullName => Firstname + " " + Lastname;

    }
}