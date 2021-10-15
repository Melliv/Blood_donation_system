
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.BloodDonate
{
    public partial class CreateViewModel
    {
        public DTO.App.V1.BloodDonate BloodDonate { get; set; } = new();

        public SelectList Patients { get; set; } = default!;

        public SelectList Doctors { get; set; }= default!;
        
        public SelectList BloodTests { get; set; }= default!;

    }
}