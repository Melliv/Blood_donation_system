using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.BLL.App;
using DAL.App.EF;
using Domain.App;
using DTO.App.V1.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApp.ViewModels.PersonType;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PersonTypeAdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IAppBLL _bll;
        private readonly PersonTypeMapper _personTypeMapper;

        public PersonTypeAdminController(AppDbContext context, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _bll = bll;
            _personTypeMapper = new PersonTypeMapper(mapper);
        }

        // GET: PersonTypeAdmin
        public async Task<IActionResult> Index()
        {
            var vm = new IndexViewModel();
            vm.PersonTypes = (await _bll.PersonType.GetAllAsync()).Select(b => _personTypeMapper.Map(b)).ToList();
            return View(vm);
        }

        // GET: PersonTypeAdmin/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();
            
            var vm = new DetailsViewModel();
            var personTypes = _personTypeMapper.Map(await _bll.PersonType.FirstOrDefaultAsync((Guid) id));

            if (personTypes == null) return NotFound();
            
            vm.PersonType = personTypes;
            return View(vm);
        }

        // GET: PersonTypeAdmin/Create
        public IActionResult Create()
        {
            return View(new CreateViewModel());
        }

        // POST: PersonTypeAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DTO.App.V1.PersonType personType)
        {
            
            if (!ModelState.IsValid) RedirectToAction(nameof(Create), personType);
            
            var personTypeDTO = _personTypeMapper.Map(personType);
            
            if (personTypeDTO == null) RedirectToAction(nameof(Create), personType);
            
            var personTypeBLL = _bll.PersonType.Add(personTypeDTO!);
            await _bll.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = personTypeBLL.Id });
        }

        // GET: PersonTypeAdmin/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var personType = _personTypeMapper.Map(await _bll.PersonType.FirstOrDefaultAsync((Guid) id));
            if (personType == null) return NotFound();

            var vm = new CreateViewModel();
            vm.PersonType = personType;
            return View(vm);
        }

        // POST: PersonTypeAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DTO.App.V1.PersonType personType)
        {
            if (id != personType.Id) return NotFound();
            if (!ModelState.IsValid) return RedirectToAction(nameof(Edit), new { id } );

            var personTypeDTO = _personTypeMapper.Map(personType)!;
            _bll.PersonType.Update(personTypeDTO);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        // GET: PersonTypeAdmin/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();
            
            var vm = new DetailsViewModel();
            var personType = _personTypeMapper.Map(await _bll.PersonType.FirstOrDefaultAsync((Guid) id));

            if (personType == null) return NotFound();
            
            vm.PersonType = personType;
            return View(vm);
        }

        // POST: PersonTypeAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var personType = await _bll.PersonType.FirstOrDefaultAsync(id);
            if (personType == null) RedirectToAction(nameof(Delete), id);
            try
            {
                _bll.PersonType.Remove(personType!);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                return RedirectToAction(nameof(Delete));
            }
            
            return RedirectToAction(nameof(Index));
        }

    }
}
