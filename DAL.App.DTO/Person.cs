using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace DAL.App.DTO
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
        public DAL.App.DTO.BloodGroup? BloodGroup { get; set; }
        
        [InverseProperty(nameof(BloodTest.Donor))]
        public ICollection<BloodTest>? BloodTestsDonors { get; set; }
        [InverseProperty(nameof(BloodTest.Doctor))]
        public ICollection<BloodTest>? BloodTestsDoctors { get; set; }
        
        [InverseProperty(nameof(BloodDonate.Donor))]
        public ICollection<BloodDonate>? BloodDonateDonors { get; set; }
        [InverseProperty(nameof(BloodDonate.Doctor))]
        public ICollection<BloodDonate>? BloodDonateDoctors { get; set; }
        
        [InverseProperty(nameof(BloodTransfusion.Donor))]
        public ICollection<BloodTransfusion>? BloodTransfusionDonors { get; set; }
        [InverseProperty(nameof(BloodTransfusion.Doctor))]
        public ICollection<BloodTransfusion>? BloodTransfusionDoctors { get; set; }
        
        [InverseProperty(nameof(Contact.Person))]
        public ICollection<Contact>? Contacts { get; set; }

        public string FullName => Firstname + " " + Lastname;

    }
}