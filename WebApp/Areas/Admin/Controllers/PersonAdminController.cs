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
    public class PersonAdminController : Controller
    {
        private readonly AppDbContext _context;

        public PersonAdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PersonAdmin
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Person.Include(p => p.BloodGroup).Include(p => p.PersonType);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PersonAdmin/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .Include(p => p.BloodGroup)
                .Include(p => p.PersonType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: PersonAdmin/Create
        public IActionResult Create()
        {
            ViewData["BloodGroupId"] = new SelectList(_context.BloodGroup, "Id", "BloodGroupValue");
            ViewData["PersonTypeId"] = new SelectList(_context.PersonType, "Id", "CreatedBy");
            return View();
        }

        // POST: PersonAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Firstname,Lastname,IdentificationCode,Comments,PersonTypeId,BloodGroupId,CreatedBy,CreateAt,UpdateBy,UpdatedAt,Id")] Person person)
        {
            if (ModelState.IsValid)
            {
                person.Id = Guid.NewGuid();
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BloodGroupId"] = new SelectList(_context.BloodGroup, "Id", "BloodGroupValue", person.BloodGroupId);
            ViewData["PersonTypeId"] = new SelectList(_context.PersonType, "Id", "CreatedBy", person.PersonTypeId);
            return View(person);
        }

        // GET: PersonAdmin/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            ViewData["BloodGroupId"] = new SelectList(_context.BloodGroup, "Id", "BloodGroupValue", person.BloodGroupId);
            ViewData["PersonTypeId"] = new SelectList(_context.PersonType, "Id", "CreatedBy", person.PersonTypeId);
            return View(person);
        }

        // POST: PersonAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Firstname,Lastname,IdentificationCode,Comments,PersonTypeId,BloodGroupId,CreatedBy,CreateAt,UpdateBy,UpdatedAt,Id")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
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
            ViewData["BloodGroupId"] = new SelectList(_context.BloodGroup, "Id", "BloodGroupValue", person.BloodGroupId);
            ViewData["PersonTypeId"] = new SelectList(_context.PersonType, "Id", "CreatedBy", person.PersonTypeId);
            return View(person);
        }

        // GET: PersonAdmin/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .Include(p => p.BloodGroup)
                .Include(p => p.PersonType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: PersonAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var person = await _context.Person.FindAsync(id);
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(Guid id)
        {
            return _context.Person.Any(e => e.Id == id);
        }
    }
}
