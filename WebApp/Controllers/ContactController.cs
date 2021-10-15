using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.App;
using DTO.App.V1.Mappers;
using Extensions.Base;
using Microsoft.Extensions.Logging;
using WebApp.ViewModels.Contact;

namespace WebApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppBLL _bll;
        private readonly ContactMapper _contactMapper;

        public ContactController(ILogger<HomeController> logger, IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _logger = logger;
            _contactMapper = new ContactMapper(mapper);
        }


        // GET: Contact
        public async Task<IActionResult> Index(Guid personId)
        {
            
            IndexViewModel vm = new ();
            var contacts = await _bll.Contacts.GetAllSpecificPersonAsync(personId);
            vm.Contacts = contacts.Select(b => _contactMapper.Map(b)!).ToList();
            vm.PersonId = personId;
            
            return View(vm);
        }
        

        // GET: Contact/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == default) return NotFound();
            
            var contact = await _bll.Contacts.FirstOrDefaultAsync(id);
            DetailsViewModel vm = new ();
            vm.Contact = _contactMapper.Map(contact)!;

            return View(vm);
        }
        

        public async Task<IActionResult> Create(Guid personId)
        {
            if (personId == default) return NotFound();
            
            CreateViewModel vm = new();
            vm.Contact.PersonId = personId;
            
            var contactTypes = await _bll.ContactTypes.GetAllAsync();
            vm.ContactTypes = new SelectList(contactTypes, "Id", nameof(ContactType.ContactTypeValue));
            
            return View(vm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var contactTypes = await _bll.Contacts.GetAllAsync();
                vm.ContactTypes = new SelectList(contactTypes, "Id", nameof(ContactType.ContactTypeValue));
                return View(vm);
            }

            var contactDTO = _contactMapper.Map(vm.Contact);
            var contactBLL = _bll.Contacts.Add(contactDTO!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { contactBLL.PersonId });
        }

        
        // GET: Contact/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == default) return NotFound();

            var contact = await _bll.Contacts.FirstOrDefaultAsync(id);

            CreateViewModel vm = new ();
            vm.Contact = _contactMapper.Map(contact)!;
            var contactTypes = await _bll.ContactTypes.GetAllAsync();
            vm.ContactTypes = new SelectList(contactTypes, "Id",  nameof(ContactType.ContactTypeValue), contact!.ContactTypeId);
            return View(vm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var contactTypes = await _bll.ContactTypes.GetAllAsync();
                vm.ContactTypes = new SelectList(contactTypes, "Id",  nameof(Contact.ContactValue), vm.Contact.ContactTypeId);
                return View(vm);
            }
            
            vm.Contact.Id = id;
            var contactBLL = _contactMapper.Map(vm.Contact);
            contactBLL = _bll.Contacts.Update(contactBLL!);
            await _bll.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { contactBLL.PersonId });
        }

        // GET: Contact/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == default) return NotFound();

            var contact = await _bll.Contacts.FirstOrDefaultAsync(id);
            DetailsViewModel vm = new ();
            vm.Contact = _contactMapper.Map(contact)!;

            return View(vm);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, Guid personId)
        {
            var contact = await _bll.Contacts.FirstOrDefaultAsync(id);
            if (contact == null) return NotFound();
            _bll.Contacts.Remove(contact);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index),new { personId } );
        }
        
    }
}
