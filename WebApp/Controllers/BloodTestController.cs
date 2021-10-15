using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.BLL.App;
using Domain.App;
using DTO.App.V1.Mappers;
using Extensions.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WebApp.ViewModels.BloodTest;

namespace WebApp.Controllers
{
    public class BloodTestController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppBLL _bll;
        private readonly BloodTestMapper _bloodTestMapper;


        public BloodTestController(ILogger<HomeController> logger, IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _logger = logger;
            _bloodTestMapper = new BloodTestMapper(mapper);
        }

        // GET: BloodTest
        public async Task<IActionResult> Index(Guid? personId)
        {
            IndexViewModel vm = new ();
            var bloodTests = ((personId == null) ? 
                (await _bll.BloodTest.GetAllAsync(User.GetUserId()!.Value)) : 
                (await _bll.BloodTest.GetAllByPatientId(personId)))
                .Select(b => _bloodTestMapper.Map(b)).ToList();

            vm.BloodTests = bloodTests;
            return View(vm);
        }

        // GET: BloodTest/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == default) return NotFound();
            
            DetailsViewModel vm = new();
            var bloodTestDTO = _bloodTestMapper.Map(await _bll.BloodTest.FirstOrDefaultAsync(id, User.GetUserId()!.Value));
            if (bloodTestDTO == null) return NotFound();
            vm.BloodTest = bloodTestDTO;
            return View(vm);
        }

        // GET: BloodTest/Create
        public async Task<IActionResult> Create(Guid? personId, Guid? bloodGroupId)
        {
            CreateViewModel vm = await AddCreatInitialData();
            if (personId != null) vm.BloodTest.DonorId = (Guid) personId;
            if (bloodGroupId != null) vm.BloodTest.BloodGroupId = (Guid) bloodGroupId;
            return View(vm);
        }

        // POST: BloodTest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DTO.App.V1.BloodTest bloodTest)
        {
            if (!ModelState.IsValid)
            {
                CreateViewModel vm = await AddCreatInitialData();
                vm.BloodTest = bloodTest;
                return View(vm);
            }
            var bloodTestBLL = _bloodTestMapper.Map(bloodTest);
            
            bloodTestBLL!.CreatedBy = User.GetName() ?? "";
            bloodTestBLL!.CreateAt = DateTime.Now;
            bloodTestBLL = _bll.BloodTest.Add(bloodTestBLL);
            await _bll.SaveChangesAsync();
            
            await _bll.Persons.PutBloodGroupIfNeeded((Guid) bloodTestBLL!.DonorId!, (Guid) bloodTestBLL!.BloodGroupId!);
            
            return RedirectToAction(nameof(Details), new { id = bloodTestBLL.Id });

        }
        
        private async Task<CreateViewModel> AddCreatInitialData()
        {
            var patients = await _bll.Persons.GetAllAsync(User.GetUserId()!.Value);
            var doctors = await _bll.Persons.GetAllSpecificPersonsByPersonTypeAsync("Doctor");
            var bloodGroups = await _bll.BloodGroup.GetAllAsync(User.GetUserId()!.Value);

            CreateViewModel vm = new ();
            vm.Patients = 
                new SelectList(patients, "Id", nameof(Person.FullName), vm.BloodTest.DonorId);
            vm.Doctors =
                new SelectList(doctors, "Id", nameof(Person.FullName), vm.BloodTest.DoctorId);
            vm.BloodGroups =
                new SelectList(bloodGroups, "Id", nameof(DTO.App.V1.BloodGroup.BloodGroupValue), vm.BloodTest.BloodGroupId);

            return vm;
        }
        
    }
}