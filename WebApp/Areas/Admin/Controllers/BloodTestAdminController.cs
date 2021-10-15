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
    public class BloodTestAdminController : Controller
    {
        private readonly AppDbContext _context;

        public BloodTestAdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BloodTestAdmin
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.BloodTest.Include(b => b.BloodGroup).Include(b => b.Doctor).Include(b => b.Donor);
            return View(await appDbContext.ToListAsync());
        }

        // GET: BloodTestAdmin/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodTest = await _context.BloodTest
                .Include(b => b.BloodGroup)
                .Include(b => b.Doctor)
                .Include(b => b.Donor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodTest == null)
            {
                return NotFound();
            }

            return View(bloodTest);
        }

        // GET: BloodTestAdmin/Create
        public IActionResult Create()
        {
            ViewData["BloodGroupId"] = new SelectList(_context.BloodGroup, "Id", "BloodGroupValue");
            ViewData["DoctorId"] = new SelectList(_context.Person, "Id", "CreatedBy");
            ViewData["DonorId"] = new SelectList(_context.Person, "Id", "CreatedBy");
            return View();
        }

        // POST: BloodTestAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Allowed,Comments,DonorId,DoctorId,BloodGroupId,CreatedBy,CreateAt,UpdateBy,UpdatedAt,Id")] BloodTest bloodTest)
        {
            if (ModelState.IsValid)
            {
                bloodTest.Id = Guid.NewGuid();
                _context.Add(bloodTest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BloodGroupId"] = new SelectList(_context.BloodGroup, "Id", "BloodGroupValue", bloodTest.BloodGroupId);
            ViewData["DoctorId"] = new SelectList(_context.Person, "Id", "CreatedBy", bloodTest.DoctorId);
            ViewData["DonorId"] = new SelectList(_context.Person, "Id", "CreatedBy", bloodTest.DonorId);
            return View(bloodTest);
        }

        // GET: BloodTestAdmin/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodTest = await _context.BloodTest.FindAsync(id);
            if (bloodTest == null)
            {
                return NotFound();
            }
            ViewData["BloodGroupId"] = new SelectList(_context.BloodGroup, "Id", "BloodGroupValue", bloodTest.BloodGroupId);
            ViewData["DoctorId"] = new SelectList(_context.Person, "Id", "CreatedBy", bloodTest.DoctorId);
            ViewData["DonorId"] = new SelectList(_context.Person, "Id", "CreatedBy", bloodTest.DonorId);
            return View(bloodTest);
        }

        // POST: BloodTestAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Allowed,Comments,DonorId,DoctorId,BloodGroupId,CreatedBy,CreateAt,UpdateBy,UpdatedAt,Id")] BloodTest bloodTest)
        {
            if (id != bloodTest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bloodTest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloodTestExists(bloodTest.Id))
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
            ViewData["BloodGroupId"] = new SelectList(_context.BloodGroup, "Id", "BloodGroupValue", bloodTest.BloodGroupId);
            ViewData["DoctorId"] = new SelectList(_context.Person, "Id", "CreatedBy", bloodTest.DoctorId);
            ViewData["DonorId"] = new SelectList(_context.Person, "Id", "CreatedBy", bloodTest.DonorId);
            return View(bloodTest);
        }

        // GET: BloodTestAdmin/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodTest = await _context.BloodTest
                .Include(b => b.BloodGroup)
                .Include(b => b.Doctor)
                .Include(b => b.Donor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodTest == null)
            {
                return NotFound();
            }

            return View(bloodTest);
        }

        // POST: BloodTestAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bloodTest = await _context.BloodTest.FindAsync(id);
            _context.BloodTest.Remove(bloodTest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloodTestExists(Guid id)
        {
            return _context.BloodTest.Any(e => e.Id == id);
        }
    }
}
