using System;
using System.Collections.Generic;
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
using WebApp.ViewModels.BloodTransfusion;
using BloodTransfusion = DTO.App.V1.BloodTransfusion;

namespace WebApp.Controllers
{
    public class BloodTransfusionController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppBLL _bll;
        private readonly IMapper _iMapper;

        private readonly BloodTransfusionMapper _bloodTransfusionMapper;


        public BloodTransfusionController(ILogger<HomeController> logger, IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _logger = logger;
            _iMapper = mapper;
            _bloodTransfusionMapper = new BloodTransfusionMapper(mapper);
        }

        // GET: BloodDonate
        public async Task<IActionResult> Index(Guid? personId)
        {
            ViewModels.BloodTransfusion.IndexViewModel vm = new ();
            var bloodDonates = ((personId == null)
                    ? (await _bll.BloodTransfusion.GetAllAsync(User.GetUserId()!.Value))
                    : (await _bll.BloodTransfusion.GetAllByPatientId(personId)))
                    .Select(b => _bloodTransfusionMapper.Map(b)).ToList();
            
            vm.BloodTransfusions = bloodDonates;
            return View(vm);
        }

        // GET: BloodDonate/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == default) return NotFound();


            DetailsViewModel vm = new();
            var bloodTransfusionBLL = await _bll.BloodTransfusion.FirstOrDefaultAsync(id, User.GetUserId()!.Value);
            var bloodDonateDTO = _bloodTransfusionMapper.Map(bloodTransfusionBLL);
            
            if (bloodDonateDTO == null) return NotFound();

            vm.BloodTransfusions = bloodDonateDTO;
            
            var transferableBloodMapper = new TransferableBloodMapper(_iMapper);
            vm.TransferableBlood = (await _bll.TransferableBlood.GetAllByTransfusionIdAsync(id)).Select(t => transferableBloodMapper.Map(t)).ToList();

            return View(vm);
        }

        // GET: BloodDonate/Create
        public async Task<IActionResult> Create(Guid? personId, Guid? bloodGroupId, int? error)
        {
            CreateViewModel vm = await AddCreatInitialData(null);
            if (error is 1) vm.Error = 1;
            if (personId != null && bloodGroupId != null)
            {
                vm.BloodTransfusions.DonorId = (Guid) personId;
                vm.BloodTransfusions.BloodGroupId = (Guid) bloodGroupId;
            }
            return View(vm);
        }

        // POST: BloodDonate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel vm)
        {
            if (!ModelState.IsValid) 
                return RedirectToAction(nameof(Create), 
                    new {personId = vm.BloodTransfusions.DonorId, bloodGroupId = vm.BloodTransfusions.BloodGroupId});

            var bloodTransfusionBLL = _bloodTransfusionMapper.Map(vm.BloodTransfusions);

            if (!_bll.BloodDonate.CanTransfuseBlood(User.GetUserId()!.Value, bloodTransfusionBLL!.Amount, bloodTransfusionBLL.BloodGroupId))
                return RedirectToAction(nameof(Create), 
                    new {personId = bloodTransfusionBLL.DonorId, bloodGroupId = bloodTransfusionBLL.BloodGroupId, error = 1});

            bloodTransfusionBLL.CreateAt = DateTime.Now;
            bloodTransfusionBLL = _bll.BloodTransfusion.Add(bloodTransfusionBLL);

            await _bll.SaveChangesAsync();
            
            _bll.TransferableBlood.AddFixedAmount(bloodTransfusionBLL!.Amount, bloodTransfusionBLL.BloodGroupId, bloodTransfusionBLL.Id);

            return RedirectToAction(nameof(Details), new {id = bloodTransfusionBLL.Id});
        }
        
        private async Task<ViewModels.BloodTransfusion.CreateViewModel> AddCreatInitialData(CreateViewModel? vm)
        {
            if (vm == null) vm = new CreateViewModel();
            var patients = await _bll.Persons.GetAllAsync(User.GetUserId()!.Value);
            var doctors = await _bll.Persons.GetAllSpecificPersonsByPersonTypeAsync("Doctor");
            var bloodTests = await _bll.BloodGroup.GetAllAsync(User.GetUserId()!.Value);
            
            vm.Patients = new SelectList(patients, "Id", nameof(Person.FullName), vm.BloodTransfusions.DonorId);
            vm.Doctors = new SelectList(doctors, "Id", nameof(Person.FullName), vm.BloodTransfusions.DoctorId);
            vm.BloodGroups = new SelectList(bloodTests, "Id", nameof(BloodGroup.BloodGroupValue), vm.BloodTransfusions.BloodGroupId);
            return vm;
        }
    }
}