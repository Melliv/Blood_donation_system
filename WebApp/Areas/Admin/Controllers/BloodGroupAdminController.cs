using System;
using System.Linq;
using System.Threading.Tasks;
using DAL.App.EF;
using Domain.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BloodGroupAdminController : Controller
    {
        private readonly AppDbContext _context;

        public BloodGroupAdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BloodGroupAdmin
        public async Task<IActionResult> Index()
        {
            return View(await _context.BloodGroup.ToListAsync());
        }

        // GET: BloodGroupAdmin/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodGroup = await _context.BloodGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodGroup == null)
            {
                return NotFound();
            }

            return View(bloodGroup);
        }

        // GET: BloodGroupAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BloodGroupAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BloodGroupValue,CreatedBy,CreateAt,UpdateBy,UpdatedAt,Id")] BloodGroup bloodGroup)
        {
            if (ModelState.IsValid)
            {
                bloodGroup.Id = Guid.NewGuid();
                _context.Add(bloodGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bloodGroup);
        }

        // GET: BloodGroupAdmin/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodGroup = await _context.BloodGroup.FindAsync(id);
            if (bloodGroup == null)
            {
                return NotFound();
            }
            return View(bloodGroup);
        }

        // POST: BloodGroupAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BloodGroupValue,CreatedBy,CreateAt,UpdateBy,UpdatedAt,Id")] BloodGroup bloodGroup)
        {
            if (id != bloodGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bloodGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloodGroupExists(bloodGroup.Id))
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
            return View(bloodGroup);
        }

        // GET: BloodGroupAdmin/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodGroup = await _context.BloodGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodGroup == null)
            {
                return NotFound();
            }

            return View(bloodGroup);
        }

        // POST: BloodGroupAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bloodGroup = await _context.BloodGroup.FindAsync(id);
            _context.BloodGroup.Remove(bloodGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloodGroupExists(Guid id)
        {
            return _context.BloodGroup.Any(e => e.Id == id);
        }
    }
}
