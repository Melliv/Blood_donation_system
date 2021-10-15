using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.BLL.App;
using DTO.App.V1;
using DTO.App.V1.Mappers;
using Extensions.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WebApp.ViewModels.person;
using BloodGroup = BLL.App.DTO.BloodGroup;
using Person = DTO.App.V1.Person;
using PersonType = BLL.App.DTO.PersonType;

namespace WebApp.Controllers
{
    [Authorize]
    public class PersonsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppBLL _bll;
        private readonly PersonMapper _personMapper;


        public PersonsController(ILogger<HomeController> logger, IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _logger = logger;
            _personMapper = new PersonMapper(mapper);
        }

        [HttpGet]
        public async Task<IActionResult> Index(IndexViewModel vm, string? firstName, string? lastName, string? identificationCode)
        {
            if (firstName == null && lastName == null && identificationCode == null) return View(vm);
            
            DTO.App.V1.Person person = new Person()
            {
                Firstname = firstName!,
                Lastname = lastName!,
                IdentificationCode = identificationCode!
            };

            var personBLL = _personMapper.Map(person)!;
            var personsDTO = (await _bll.Persons.GetAllSpecificsPersonsAsync(personBLL))
                .Select(p => _personMapper.Map(p)).ToList();
            vm.Persons = personsDTO;
            vm.Person = new DTO.App.V1.SearchPerson
            {
                Firstname = person.Firstname,
                Lastname = person.Lastname,
                IdentificationCode = person.IdentificationCode
            };
            return View(vm);
        }
        
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var exists = await _bll.Persons.ExistsAsync(id.Value);
            if (!exists) return NotFound();
            
            var personDTO = _personMapper.Map(await _bll.Persons.FirstWidthIncludeAsync(id.Value));

            if (personDTO == null) return NotFound();

            DetailsViewModel vm = new ();
            vm.Person = personDTO;

            var personBloodDonateInfo = new PersonBloodDonateInfo();
            var data = await _bll.BloodDonate.GetLastDonateByPersonId(personDTO.Id);
            personBloodDonateInfo.Date = data == null ? null : data!.Value.AddMonths(6);
            personBloodDonateInfo.Allowed = personBloodDonateInfo.Date == null || personBloodDonateInfo.Date < DateTime.Now;

            vm.PersonBloodDonateInfo = personBloodDonateInfo;
            return View(vm);
        }
        
        public async Task<IActionResult> Create()
        {
            CreateViewModel vm = await AddCreatInitialData();
            return View(vm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Person person)
        {
            var temp = ModelState;
            if (!ModelState.IsValid) return BadRequest();

            person.CreatedBy = User.GetName() ?? "";
            var personBLL = _personMapper.Map(person)!;

            personBLL = _bll.Persons.Add(personBLL);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = personBLL.Id });
        }

        private async Task<CreateViewModel> AddCreatInitialData()
        {
            CreateViewModel vm = new();
            var personTypes = await _bll.PersonType.GetAllAsync();
            var bloodGroups = await _bll.BloodGroup.GetAllAsync();
                
            vm.PersonTypes = 
                new SelectList(personTypes, "Id", nameof(PersonType.PersonTypeValue), vm.Person.PersonTypeId);
            vm.BloodGroups =
                new SelectList(bloodGroups, "Id", nameof(BloodGroup.BloodGroupValue), vm.Person.BloodGroupId);

            return vm;
        }
    }
}