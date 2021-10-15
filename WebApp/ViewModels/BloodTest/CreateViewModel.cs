
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.BloodTest
{
    public class CreateViewModel
    {
        public DTO.App.V1.BloodTest BloodTest { get; set; } = new ();
        
        public SelectList Patients { get; set; } = default!;

        public SelectList Doctors { get; set; } = default!;
        
        public SelectList BloodGroups { get; set; } = default!;
    }
}