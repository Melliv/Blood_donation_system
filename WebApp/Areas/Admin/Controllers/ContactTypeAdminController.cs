using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain.App;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactTypeAdminController : Controller
    {
        private readonly AppDbContext _context;

        public ContactTypeAdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ContactTypeAdmin
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ContactType.Include(c => c.ContactTypeValue);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ContactTypeAdmin/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactType = await _context.ContactType
                .Include(c => c.ContactTypeValue)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactType == null)
            {
                return NotFound();
            }

            return View(contactType);
        }

        // GET: ContactTypeAdmin/Create
        public IActionResult Create()
        {
            ViewData["ContactTypeValueId"] = new SelectList(_context.LangStrings, "Id", "Id");
            return View();
        }

        // POST: ContactTypeAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactTypeValueId,CreatedBy,CreateAt,UpdateBy,UpdatedAt,Id")] ContactType contactType)
        {
            if (ModelState.IsValid)
            {
                contactType.Id = Guid.NewGuid();
                _context.Add(contactType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactTypeValueId"] = new SelectList(_context.LangStrings, "Id", "Id", contactType.ContactTypeValueId);
            return View(contactType);
        }

        // GET: ContactTypeAdmin/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactType = await _context.ContactType.FindAsync(id);
            if (contactType == null)
            {
                return NotFound();
            }
            ViewData["ContactTypeValueId"] = new SelectList(_context.LangStrings, "Id", "Id", contactType.ContactTypeValueId);
            return View(contactType);
        }

        // POST: ContactTypeAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ContactTypeValueId,CreatedBy,CreateAt,UpdateBy,UpdatedAt,Id")] ContactType contactType)
        {
            if (id != contactType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactTypeExists(contactType.Id))
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
            ViewData["ContactTypeValueId"] = new SelectList(_context.LangStrings, "Id", "Id", contactType.ContactTypeValueId);
            return View(contactType);
        }

        // GET: ContactTypeAdmin/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactType = await _context.ContactType
                .Include(c => c.ContactTypeValue)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactType == null)
            {
                return NotFound();
            }

            return View(contactType);
        }

        // POST: ContactTypeAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var contactType = await _context.ContactType.FindAsync(id);
            _context.ContactType.Remove(contactType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactTypeExists(Guid id)
        {
            return _context.ContactType.Any(e => e.Id == id);
        }
    }
}
