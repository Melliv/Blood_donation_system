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
    public class BloodDonateService: BaseEntityService<IAppUnitOfWork, IBloodDonateRepository, BLLAppDTO.BloodDonate, DALAppDTO.BloodDonate>, IBloodDonateService
    {
        private IMapper _mapper;
        public BloodDonateService(IAppUnitOfWork serviceUow, IBloodDonateRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new BloodDonateMapper(mapper))
        {
            _mapper = mapper;
        }

        public bool CanTransfuseBlood(Guid userId, double amount, Guid? bloodGroupId, bool noTracking = true)
        {
            return ServiceRepository.CanTransfuseBlood(userId, amount, bloodGroupId, noTracking);
        }

        public async Task<DataTable> GetStatistic()
        {
            var bloodDonates = (await ServiceRepository.GetAllIncludingBloodAsync()).ToList();
            
            var bloodDonatesInfo = bloodDonates
                .GroupBy(b => b.BloodGroupId)
                .Select(g => Mapper.Map(new DAL.App.DTO.BloodDonate()
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

        public async Task<DataTable> GetStatisticByTime()
        {
            var dt = new DataTable();

            var dayCount = 7;

            var bloodDonates = (await ServiceRepository.GetLastIndexDayAsync(dayCount)).ToList();
            
            var bloodDonatesInfo = bloodDonates
                .GroupBy(b => b.CreateAt.Day)
                .Select(g => Mapper.Map(new DAL.App.DTO.BloodDonate()
                {
                    Amount = g.Sum(b => b.Amount),
                    CreateAt = g.First().CreateAt.Date
                })!)
                .ToList();


            var transfusionsMapper = new BloodTransfusionMapper(_mapper);
            var bloodTransfusions = (await ServiceUow.BloodTransfusion.GetLastIndexDayAsync(dayCount)).ToList();
            
            var bloodTransfusionsInfo = bloodTransfusions
                .GroupBy(b => b.CreateAt.Day)
                .Select(g => transfusionsMapper.Map(new DAL.App.DTO.BloodTransfusion()
                {
                    Amount = g.Sum(b => b.Amount),
                    CreateAt = g.First().CreateAt.Date
                })!)
                .ToList();

            dt.AddColumn(new Column(ColumnType.String, "Date"));
            dt.AddColumn(new Column(ColumnType.Number, "BloodDonates", "Blood Donates"));
            dt.AddColumn(new Column(ColumnType.Number, "BloodTransfusions", "Blood Transfusions"));
            
            var date = DateTime.Now.AddDays(-dayCount+1);
            for (int i = 0; i < dayCount; i++)
            {
                var row = dt.NewRow();
                
                var bloodDonateAmount = bloodDonatesInfo.Find(b => b.CreateAt.Day == date.Day)?.Amount ?? 0;
                var bloodTransfusionAmount = bloodTransfusionsInfo.Find(b => b.CreateAt.Day == date.Day)?.Amount ?? 0;

                row.AddCellRange(new[] {new Cell(date.ToShortDateString()), new Cell(bloodDonateAmount), new Cell(bloodTransfusionAmount)});
                dt.AddRow(row);
                date = date.AddDays(+1);
            }

            return dt;
        }

        public async Task<IEnumerable<BLLAppDTO.BloodDonate>> GetAllByPatientId(Guid personId)
        {
            return (await ServiceRepository.GetAllByPatientId(personId)).Select(x => Mapper.Map(x))!;
        }

        public async Task<DateTime?> GetLastDonateByPersonId(Guid personId)
        {
            return await ServiceRepository.GetLastDonateByPersonId(personId);
        }
    }
}