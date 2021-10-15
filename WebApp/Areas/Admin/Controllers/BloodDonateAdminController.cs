using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.BLL.App;
using DAL.App.EF;
using Domain.App;
using DTO.App.V1.Mappers;
using Extensions.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.ViewModels.BloodDonate;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BloodDonateAdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IAppBLL _bll;
        private readonly BloodDonateMapper _bloodDonateMapper;

        public BloodDonateAdminController(AppDbContext context, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _bll = bll;
            _bloodDonateMapper = new BloodDonateMapper(mapper);
        }

        // GET: BloodDonateAdmin
        public async Task<IActionResult> Index()
        {
            var vm = new IndexViewModel();
            vm.BloodDonates = (await _bll.BloodDonate.GetAllAsync()).Select(b => _bloodDonateMapper.Map(b)).ToList();
            return View(vm);
        }

        // GET: BloodDonateAdmin/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();
            
            var vm = new DetailsViewModel();
            var bloodDonate = _bloodDonateMapper.Map(await _bll.BloodDonate.FirstOrDefaultAsync((Guid) id));

            if (bloodDonate == null) return NotFound();
            
            vm.BloodDonate = bloodDonate;
            return View(vm);
        }

        // GET: BloodDonateAdmin/Create
        public async Task<IActionResult> Create()
        {
            var vm = await AddCreatInitialData();
            return View(vm);
        }

        // POST: BloodDonateAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: BloodDonateAdmin/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var bloodDonate = await _bll.BloodDonate.FirstOrDefaultAsync((Guid) id);
            if (bloodDonate == null) return NotFound();
            
            var vm = await AddCreatInitialData();
            vm.BloodDonate = _bloodDonateMapper.Map(bloodDonate)!;
            return View(vm);
        }

        // POST: BloodDonateAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DTO.App.V1.BloodDonate bloodDonate)
        {
            if (id != bloodDonate.Id) return NotFound();
            if (!ModelState.IsValid) return RedirectToAction(nameof(Index), new { id } );

            var bloodDonateDTO = _bloodDonateMapper.Map(bloodDonate)!;
            _bll.BloodDonate.Update(bloodDonateDTO);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        // GET: BloodDonateAdmin/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();
            
            var vm = new DetailsViewModel();
            var bloodDonate = _bloodDonateMapper.Map(await _bll.BloodDonate.FirstOrDefaultAsync((Guid) id));

            if (bloodDonate == null) return NotFound();
            
            vm.BloodDonate = bloodDonate;
            return View(vm);
        }

        // POST: BloodDonateAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bloodDonate = await _bll.BloodDonate.FirstOrDefaultAsync(id);
            if (bloodDonate == null) RedirectToAction(nameof(Delete), id);
            _bll.BloodDonate.Remove(bloodDonate!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<CreateViewModel> AddCreatInitialData()
        {
            var patients = await _bll.Persons.GetAllAsync(User.GetUserId()!.Value);
            var doctors = await _bll.Persons.GetAllSpecificPersonsByPersonTypeAsync("Doctor");
            var bloodTests = await _bll.BloodTest.GetAllAsync(User.GetUserId()!.Value);

            CreateViewModel vm = new ();
            vm.Patients = 
                new SelectList(patients, "Id", nameof(BLL.App.DTO.Person.FullName), vm.BloodDonate.DonorId);
            vm.Doctors =
                new SelectList(doctors, "Id", nameof(BLL.App.DTO.Person.FullName), vm.BloodDonate.DoctorId);
            vm.BloodTests =
                new SelectList(bloodTests, "Id", nameof(DTO.App.V1.BloodTest.CreateAt), vm.BloodDonate.BloodTestId);
            
            return vm;
        }
    }
    
}
