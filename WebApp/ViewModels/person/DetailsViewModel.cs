using DTO.App.V1;

namespace WebApp.ViewModels.person
{
    public class DetailsViewModel
    {
        public Person Person { get; set; } = default!;
        
        public PersonBloodDonateInfo? PersonBloodDonateInfo  { get; set; }
    }
}