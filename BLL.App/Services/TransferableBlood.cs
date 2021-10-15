using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace BLL.App.Services
{
    public class TransferableBloodService: BaseEntityService<IAppUnitOfWork, ITransferableBloodRepository, BLLAppDTO.TransferableBlood, DALAppDTO.TransferableBlood>, ITransferableBloodService
    {
        public TransferableBloodService(IAppUnitOfWork serviceUow, ITransferableBloodRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new TransferableBloodMapper(mapper))
        {
        }

        public void AddFixedAmount(double amount, Guid? bloodGroupId, Guid bloodTransfusionId)
        {
            //List<Task> tasks = new List<Task>();
            //List<DALAppDTO.BloodDonate> bloodDonatesToUpdate = new List<DALAppDTO.BloodDonate>();
            var bloodDonates = ServiceUow.BloodDonate.GetAllAvailableSpecificBloodGroup(bloodGroupId).ToList();
            var counter = 0;
            while (amount > 0)
            {
                DALAppDTO.BloodDonate bloodDonate = bloodDonates[counter];
                double transBloodAmount = bloodDonate.Amount > amount ? amount : bloodDonate.Amount;

                var transferableBlood = new DALAppDTO.TransferableBlood()
                {
                    Amount = transBloodAmount,
                    BloodDonateId = bloodDonate.Id,
                    BloodTransfusionId = bloodTransfusionId,
                    CreateAt = DateTime.Now
                };

                ServiceRepository.Add(transferableBlood);
                
                // TODO update bloodDonate (available). Tracking problem!!!
                //bloodDonate.Available = false;
                //bloodDonatesToUpdate.Add(bloodDonate);

                amount -= transBloodAmount;
            }
            //ServiceUow.BloodDonate.UpdateRange(bloodDonatesToUpdate);
            ServiceUow.SaveChanges();
        }

        public async Task<IEnumerable<BLLAppDTO.TransferableBlood>> GetAllByTransfusionIdAsync(Guid transfusionId)
        {
            return (await ServiceRepository.GetAllByTransfusionIdAsync(transfusionId)).Select(x => Mapper.Map(x))!;
        }
    }
}