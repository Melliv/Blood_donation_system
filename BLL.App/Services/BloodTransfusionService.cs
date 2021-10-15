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
using Google.DataTable.Net.Wrapper;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace BLL.App.Services
{
    public class BloodTransfusionService: BaseEntityService<IAppUnitOfWork, IBloodTransfusionRepository, BLLAppDTO.BloodTransfusion, DALAppDTO.BloodTransfusion>, IBloodTransfusionService
    {
        public BloodTransfusionService(IAppUnitOfWork serviceUow, IBloodTransfusionRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new BloodTransfusionMapper(mapper))
        {
        }

        public async Task<DataTable> GetStatistic()
        {
            var bloodDonates = (await ServiceRepository.GetAllIncludingBloodAsync()).ToList();
            
            var bloodDonatesInfo = bloodDonates
                .GroupBy(b => b.BloodGroupId)
                .Select(g => Mapper.Map(new DAL.App.DTO.BloodTransfusion()
                {
                    Amount = g.Sum(b => b.Amount),
                    BloodGroup = g.First().BloodGroup
                })!)
                .ToList();

            var dt = new DataTable();
            
            dt.AddColumn(new Column(ColumnType.String, "task", "Task"));
            dt.AddColumn(new Column(ColumnType.Number, "hours", "Hours per Day"));

            foreach (var bloodDonate in bloodDonatesInfo)
            {
                Row row = dt.NewRow();
                row.AddCellRange(new[] {new Cell(bloodDonate.BloodGroup!.BloodGroupValue), new Cell(bloodDonate.Amount)});
                dt.AddRow(row);
            }

            return dt;
        }

        public async Task<IEnumerable<BLLAppDTO.BloodTransfusion>> GetAllByPatientId(Guid? personId)
        {
            return (await ServiceRepository.GetAllByPatientId(personId)).Select(x => Mapper.Map(x))!;
        }
    }
}