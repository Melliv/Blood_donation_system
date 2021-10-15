using System.Collections.Generic;

namespace WebApp.ViewModels.BloodTransfusion
{
    public class DetailsViewModel
    {
        public DTO.App.V1.BloodTransfusion BloodTransfusions { get; set; } = default!;

        public List<DTO.App.V1.TransferableBlood?> TransferableBlood { get; set; } = default!;
    }
}