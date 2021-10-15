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
    public class ContactAdminController : Controller
    {
        private readonly AppDbContext _context;

        public ContactAdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ContactAdmin
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Contact.Include(c => c.ContactType).Include(c => c.ContactValue).Include(c => c.Person);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ContactAdmin/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact
                .Include(c => c.ContactType)
                .Include(c => c.ContactValue)
                .Include(c => c.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: ContactAdmin/Create
        public IActionResult Create()
        {
            ViewData["ContactTypeId"] = new SelectList(_context.ContactType, "Id", "CreatedBy");
            ViewData["ContactValueId"] = new SelectList(_context.LangStrings, "Id", "Id");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "CreatedBy");
            return View();
        }

        // POST: ContactAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactValueId,ContactTypeId,PersonId,CreatedBy,CreateAt,UpdateBy,UpdatedAt,Id")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.Id = Guid.NewGuid();
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactTypeId"] = new SelectList(_context.ContactType, "Id", "CreatedBy", contact.ContactTypeId);
            ViewData["ContactValueId"] = new SelectList(_context.LangStrings, "Id", "Id", contact.ContactValueId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "CreatedBy", contact.PersonId);
            return View(contact);
        }

        // GET: ContactAdmin/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewData["ContactTypeId"] = new SelectList(_context.ContactType, "Id", "CreatedBy", contact.ContactTypeId);
            ViewData["ContactValueId"] = new SelectList(_context.LangStrings, "Id", "Id", contact.ContactValueId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "CreatedBy", contact.PersonId);
            return View(contact);
        }

        // POST: ContactAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ContactValueId,ContactTypeId,PersonId,CreatedBy,CreateAt,UpdateBy,UpdatedAt,Id")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
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
            ViewData["ContactTypeId"] = new SelectList(_context.ContactType, "Id", "CreatedBy", contact.ContactTypeId);
            ViewData["ContactValueId"] = new SelectList(_context.LangStrings, "Id", "Id", contact.ContactValueId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "CreatedBy", contact.PersonId);
            return View(contact);
        }

        // GET: ContactAdmin/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact
                .Include(c => c.ContactType)
                .Include(c => c.ContactValue)
                .Include(c => c.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: ContactAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var contact = await _context.Contact.FindAsync(id);
            _context.Contact.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(Guid id)
        {
            return _context.Contact.Any(e => e.Id == id);
        }
    }
}
