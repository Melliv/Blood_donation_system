using System;
using DTO.App.V1;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.person
{
    public class CreateViewModel
    {
        public Person Person { get; set; } = new();

        public SelectList? PersonTypes { get; set; }

        public SelectList? BloodGroups { get; set; }
    }
}