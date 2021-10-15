using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.BloodTransfusion
{
    public class CreateViewModel
    {
        public DTO.App.V1.BloodTransfusion BloodTransfusions { get; set; } = new ();
        public SelectList? Patients { get; set; }
        public SelectList? Doctors { get; set; }
        public SelectList? BloodGroups { get; set; }
        public int Error { get; set; }
    }
}