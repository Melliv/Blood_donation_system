
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.Contact
{
    public partial class CreateViewModel
    {
        public DTO.App.V1.Contact Contact { get; set; } = new();
        
        public SelectList? ContactTypes { get; set; }

    }
}