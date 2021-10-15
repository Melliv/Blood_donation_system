using System;
using System.Linq;
using System.Threading.Tasks;
using DAL.App.EF;
using Domain.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BloodTransfusionAdminController : Controller
    {
        private readonly AppDbContext _context;

        public BloodTransfusionAdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BloodTransfusionAdmin
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.BloodTransfusion.Include(b => b.BloodGroup).Include(b => b.Doctor).Include(b => b.Donor);
            return View(await appDbContext.ToListAsync());
        }

        // GET: BloodTransfusionAdmin/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodTransfusion = await _context.BloodTransfusion
                .Include(b => b.BloodGroup)
                .Include(b => b.Doctor)
                .Include(b => b.Donor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodTransfusion == null)
            {
                return NotFound();
            }

            return View(bloodTransfusion);
        }

        // GET: BloodTransfusionAdmin/Create
        public IActionResult Create()
        {
            ViewData["BloodGroupId"] = new SelectList(_context.BloodGroup, "Id", "BloodGroupValue");
            ViewData["DoctorId"] = new SelectList(_context.Person, "Id", "CreatedBy");
            ViewData["DonorId"] = new SelectList(_context.Person, "Id", "CreatedBy");
            return View();
        }

        // POST: BloodTransfusionAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Amount,Comments,DonorId,DoctorId,BloodGroupId,CreatedBy,CreateAt,UpdateBy,UpdatedAt,Id")] BloodTransfusion bloodTransfusion)
        {
            if (ModelState.IsValid)
            {
                bloodTransfusion.Id = Guid.NewGuid();
                _context.Add(bloodTransfusion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BloodGroupId"] = new SelectList(_context.BloodGroup, "Id", "BloodGroupValue", bloodTransfusion.BloodGroupId);
            ViewData["DoctorId"] = new SelectList(_context.Person, "Id", "CreatedBy", bloodTransfusion.DoctorId);
            ViewData["DonorId"] = new SelectList(_context.Person, "Id", "CreatedBy", bloodTransfusion.DonorId);
            return View(bloodTransfusion);
        }

        // GET: BloodTransfusionAdmin/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodTransfusion = await _context.BloodTransfusion.FindAsync(id);
            if (bloodTransfusion == null)
            {
                return NotFound();
            }
            ViewData["BloodGroupId"] = new SelectList(_context.BloodGroup, "Id", "BloodGroupValue", bloodTransfusion.BloodGroupId);
            ViewData["DoctorId"] = new SelectList(_context.Person, "Id", "CreatedBy", bloodTransfusion.DoctorId);
            ViewData["DonorId"] = new SelectList(_context.Person, "Id", "CreatedBy", bloodTransfusion.DonorId);
            return View(bloodTransfusion);
        }

        // POST: BloodTransfusionAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Amount,Comments,DonorId,DoctorId,BloodGroupId,CreatedBy,CreateAt,UpdateBy,UpdatedAt,Id")] BloodTransfusion bloodTransfusion)
        {
            if (id != bloodTransfusion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bloodTransfusion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloodTransfusionExists(bloodTransfusion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BloodGroupId"] = new SelectList(_context.BloodGroup, "Id", "BloodGroupValue", bloodTransfusion.BloodGroupId);
            ViewData["DoctorId"] = new SelectList(_context.Person, "Id", "CreatedBy", bloodTransfusion.DoctorId);
            ViewData["DonorId"] = new SelectList(_context.Person, "Id", "CreatedBy", bloodTransfusion.DonorId);
            return View(bloodTransfusion);
        }

        // GET: BloodTransfusionAdmin/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodTransfusion = await _context.BloodTransfusion
                .Include(b => b.BloodGroup)
                .Include(b => b.Doctor)
                .Include(b => b.Donor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodTransfusion == null)
            {
                return NotFound();
            }

            return View(bloodTransfusion);
        }

        // POST: BloodTransfusionAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bloodTransfusion = await _context.BloodTransfusion.FindAsync(id);
            _context.BloodTransfusion.Remove(bloodTransfusion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloodTransfusionExists(Guid id)
        {
            return _context.BloodTransfusion.Any(e => e.Id == id);
        }
    }
}
