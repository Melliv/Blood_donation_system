using System.Collections.Generic;

namespace WebApp.ViewModels.BloodTest
{
    public class IndexViewModel
    {
        public List<DTO.App.V1.BloodTest?> BloodTests { get; set; } = default!;
    }
}