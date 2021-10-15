using System;
using System.Collections.Generic;

namespace WebApp.ViewModels.Contact
{
    public class IndexViewModel
    {
        public Guid PersonId { get; set; }
        public List<DTO.App.V1.Contact> Contacts { get; set; } = new();

    }
}