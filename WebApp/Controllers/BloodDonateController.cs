using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.BLL.App;
using DAL.App.EF;
using DTO.App.V1.Mappers;
using Extensions.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WebApp.ViewModels.BloodDonate;

namespace WebApp.Controllers
{
    public class BloodDonateController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppBLL _bll;
        private readonly BloodDonateMapper _bloodDonateMapper;


        public BloodDonateController(ILogger<HomeController> logger, IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _logger = logger;
            _bloodDonateMapper = new BloodDonateMapper(mapper);
        }

        public async Task<IActionResult> Index(Guid? personId)
        {
            IndexViewModel vm = new IndexViewModel();
            
            vm.BloodDonates = (personId == null
                ? (await _bll.BloodDonate.GetAllAsync(User.GetUserId()!.Value))
                : (await _bll.BloodDonate.GetAllByPatientId((Guid) personId)))
                .Select(b => _bloodDonateMapper.Map(b)).ToList();
            
            return View(vm);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == default) return NotFound();
            
            DetailsViewModel vm = new();
            var bloodDonateDTO = _bloodDonateMapper.Map(await _bll.BloodDonate.FirstOrDefaultAsync(id, User.GetUserId()!.Value));
            if (bloodDonateDTO == null) return NotFound();
            
            vm.BloodDonate = bloodDonateDTO;
            return View(vm);
        }

        public async Task<IActionResult> Create(Guid? personId)
        {
            CreateViewModel vm = await AddCreatInitialData();
            if (personId != null)
            {
                vm.BloodDonate.DonorId = (Guid) personId;
            }
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DTO.App.V1.BloodDonate bloodDonate)
        {
            if (!ModelState.IsValid) RedirectToAction(nameof(Create), bloodDonate);
            
            var BloodGroupId = await _bll.Persons.GetBloodGroupIdBySpecificPersonAsync(bloodDonate.DonorId);

            if (BloodGroupId == null) RedirectToAction(nameof(Create), bloodDonate);
            
            bloodDonate.BloodGroupId = (Guid) BloodGroupId!;
            
            var bloodDonateBLL = _bloodDonateMapper.Map(bloodDonate)!;

            bloodDonateBLL!.CreateAt = DateTime.Now;
            bloodDonateBLL = _bll.BloodDonate.Add(bloodDonateBLL);
            await _bll.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = bloodDonateBLL.Id });
        }
        
        private async Task<CreateViewModel> AddCreatInitialData()
        {
            var patients = await _bll.Persons.GetAllAsync(User.GetUserId()!.Value);
            var doctors = await _bll.Persons.GetAllSpecificPersonsByPersonTypeAsync("Doctor");
            var bloodTests = await _bll.BloodTest.GetAllTodayAndAllowedAndIncludePersonAsync(User.GetUserId()!.Value);
            var bloodTestsDTO = bloodTests.Select(BloodTestMapper.ToDTOCreate).ToList();

            CreateViewModel vm = new ();
            vm.Patients = 
                new SelectList(patients, "Id", nameof(BLL.App.DTO.Person.FullName), vm.BloodDonate.DonorId);
            vm.Doctors =
                new SelectList(doctors, "Id", nameof(BLL.App.DTO.Person.FullName), vm.BloodDonate.DoctorId);
            vm.BloodTests =
                new SelectList(bloodTestsDTO, "Id", nameof(DTO.App.V1.BloodTest.OverviewData), vm.BloodDonate.BloodTestId);
            
            return vm;
        }
        
    }
}
