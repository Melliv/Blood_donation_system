using System.Collections.Generic;

namespace WebApp.ViewModels.BloodDonate
{
    public class IndexViewModel
    {
        public List<DTO.App.V1.BloodDonate?> BloodDonates { get; set; } = default!;
    }
}