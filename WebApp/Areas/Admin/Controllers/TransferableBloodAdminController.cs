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
    public class TransferableBloodAdminController : Controller
    {
        private readonly AppDbContext _context;

        public TransferableBloodAdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TransferableBloodAdmin
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TransferableBlood.Include(t => t.BloodDonate).Include(t => t.BloodTransfusion);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TransferableBloodAdmin/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferableBlood = await _context.TransferableBlood
                .Include(t => t.BloodDonate)
                .Include(t => t.BloodTransfusion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transferableBlood == null)
            {
                return NotFound();
            }

            return View(transferableBlood);
        }

        // GET: TransferableBloodAdmin/Create
        public IActionResult Create()
        {
            ViewData["BloodDonateId"] = new SelectList(_context.BloodDonate, "Id", "CreatedBy");
            ViewData["BloodTransfusionId"] = new SelectList(_context.BloodTransfusion, "Id", "CreatedBy");
            return View();
        }

        // POST: TransferableBloodAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Amount,BloodDonateId,BloodTransfusionId,CreatedBy,CreateAt,UpdateBy,UpdatedAt,Id")] TransferableBlood transferableBlood)
        {
            if (ModelState.IsValid)
            {
                transferableBlood.Id = Guid.NewGuid();
                _context.Add(transferableBlood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BloodDonateId"] = new SelectList(_context.BloodDonate, "Id", "CreatedBy", transferableBlood.BloodDonateId);
            ViewData["BloodTransfusionId"] = new SelectList(_context.BloodTransfusion, "Id", "CreatedBy", transferableBlood.BloodTransfusionId);
            return View(transferableBlood);
        }

        // GET: TransferableBloodAdmin/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferableBlood = await _context.TransferableBlood.FindAsync(id);
            if (transferableBlood == null)
            {
                return NotFound();
            }
            ViewData["BloodDonateId"] = new SelectList(_context.BloodDonate, "Id", "CreatedBy", transferableBlood.BloodDonateId);
            ViewData["BloodTransfusionId"] = new SelectList(_context.BloodTransfusion, "Id", "CreatedBy", transferableBlood.BloodTransfusionId);
            return View(transferableBlood);
        }

        // POST: TransferableBloodAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Amount,BloodDonateId,BloodTransfusionId,CreatedBy,CreateAt,UpdateBy,UpdatedAt,Id")] TransferableBlood transferableBlood)
        {
            if (id != transferableBlood.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transferableBlood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransferableBloodExists(transferableBlood.Id))
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
            ViewData["BloodDonateId"] = new SelectList(_context.BloodDonate, "Id", "CreatedBy", transferableBlood.BloodDonateId);
            ViewData["BloodTransfusionId"] = new SelectList(_context.BloodTransfusion, "Id", "CreatedBy", transferableBlood.BloodTransfusionId);
            return View(transferableBlood);
        }

        // GET: TransferableBloodAdmin/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferableBlood = await _context.TransferableBlood
                .Include(t => t.BloodDonate)
                .Include(t => t.BloodTransfusion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transferableBlood == null)
            {
                return NotFound();
            }

            return View(transferableBlood);
        }

        // POST: TransferableBloodAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var transferableBlood = await _context.TransferableBlood.FindAsync(id);
            _context.TransferableBlood.Remove(transferableBlood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransferableBloodExists(Guid id)
        {
            return _context.TransferableBlood.Any(e => e.Id == id);
        }
    }
}
