﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.App
{
    public class BloodDonate: DomainEntityMetaId
    {
        public Guid? DonorId { get; set; }
        public Person? Donor { get; set; }
        public Guid? DoctorId { get; set; }
        public Person? Doctor { get; set; }
        
        public Guid? BloodTestId { get; set; }
        public BloodTest? BloodTest { get; set; }
        public Guid? BloodGroupId { get; set; }
        public BloodGroup? BloodGroup { get; set; }
        public double Amount { get; set; }
        public bool Available { get; set; }
        public DateTime ExpireDate { get; set; }
        
        public ICollection<TransferableBlood>? TransferableBlood { get; set; }
    }
}