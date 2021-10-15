using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.App.EF;
using DTO.App.V1;
using Extensions.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using WebApp.ApiControllers.Identity;

namespace WebApp.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PersonsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly DTO.App.V1.Mappers.PersonMapper _personMapper;
        private readonly ILogger<AccountController> _logger;

        public PersonsController(IAppBLL bll, IMapper mapper, ILogger<AccountController> logger)
        {
            _bll = bll;
            _personMapper = new DTO.App.V1.Mappers.PersonMapper(mapper);
            _logger = logger;
        }

        /// <summary>
        /// Get all Persons
        /// </summary>
        /// <returns>DTO.App.V1.Person</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<DTO.App.V1.Person>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<DTO.App.V1.Person>>> GetPersons()
        {
            var personsDTO = (await _bll.Persons.GetAllAsync(User.GetUserId()!.Value)).Select(p => _personMapper.Map(p));
            return Ok(personsDTO);
        }
        
        /// <summary>
        /// Get all Persons considering parameters. Included person type and blood group.
        /// </summary>
        /// <param name="firstname">Person firstname</param>
        /// <param name="lastname">Person lastname</param>
        /// <param name="identificationcode">Personal ID</param>
        /// <returns>DTO.App.V1.Person</returns>
        [HttpGet("searchperson")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<DTO.App.V1.Person>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<DTO.App.V1.Person>>> GetPersons(string? firstname, string? lastname, string? identificationcode)
        {
            if (firstname == null && lastname == null && identificationcode == null) return NotFound();

            var person = new DTO.App.V1.Person()
            {
                Firstname = firstname ?? "",
                Lastname = lastname ?? "",
                IdentificationCode = identificationcode ?? ""
            };
            
            var personBLL = _personMapper.Map(person)!;
            var personsDTO = (await _bll.Persons.GetAllSpecificsPersonsAsync(personBLL))
                .Select(p => _personMapper.Map(p));
            return Ok(personsDTO);
        }
        
        /// <summary>
        /// Get all person by person type
        /// </summary>
        /// <param name="personType">Person type</param>
        /// <returns>Person</returns>
        [HttpGet("personType={personType}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<DTO.App.V1.Person>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<DTO.App.V1.Person>>> GetPersons(string? personType)
        {
            _logger.LogDebug(User.GetUserId()!.Value.ToString());
            if (personType == null) return NotFound();
            var personsDTO = (await _bll.Persons.GetAllSpecificPersonsByPersonTypeAsync(personType)).Select(p => _personMapper.Map(p));
            return Ok(personsDTO);
        }

        /// <summary>
        /// Get person by id
        /// </summary>
        /// <param name="id">Person id</param>
        /// <returns>DTO.App.V1.Person</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DTO.App.V1.Person), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DTO.App.V1.Person>> GetPerson(Guid id)
        {
            var personDTO = _personMapper.Map(await _bll.Persons.FirstWidthIncludeAsync(id));
            if (personDTO == null) return NotFound();
            return personDTO;
        }
        
        /// <summary>
        /// Get person bloodDonate info by person id
        /// </summary>
        /// <param name="personId">Person id</param>
        /// <returns>DTO.App.V1.Person</returns>
        [HttpGet("bloodDonateInfo={personId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DTO.App.V1.PersonBloodDonateInfo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DTO.App.V1.PersonBloodDonateInfo>> GetPersonBloodDonateInfo(Guid personId)
        {
            var personBloodDonateInfo = new PersonBloodDonateInfo();
            var data = await _bll.BloodDonate.GetLastDonateByPersonId(personId);
            personBloodDonateInfo.Date = data == null ? null : data!.Value.AddMonths(6);
            personBloodDonateInfo.Allowed = personBloodDonateInfo.Date == null || personBloodDonateInfo.Date < DateTime.Now;

            return Ok(personBloodDonateInfo);
        }

        /// <summary>
        /// Insert new person
        /// </summary>
        /// <param name="person">New person</param>
        /// <returns>Person</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DTO.App.V1.Person), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DTO.App.V1.Person>> PostPerson(DTO.App.V1.Person person)
        {
            _logger.LogWarning(JsonSerializer.Serialize(person));
            var personBLL = _personMapper.Map(person);
            if (personBLL == null) return BadRequest();
            personBLL.CreateAt = DateTime.Now;
            personBLL.UpdatedAt = DateTime.Now;
            var personDTO = _personMapper.Map(_bll.Persons.Add(personBLL));
            if (personDTO == null) return BadRequest();
            await _bll.SaveChangesAsync();
            return CreatedAtAction("GetPerson", new { id = personDTO.Id }, personDTO);
        }

        // // PUT: api/Persons/5
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutPerson(Guid id, BLL.App.DTO.Person person)
        // {
        //     if (id != person.Id)
        //     {
        //         return BadRequest();
        //     }
        //
        //     _bll.Persons.Update(person);
        //     await _bll.SaveChangesAsync();
        //
        //     return NoContent();
        // }


        // // DELETE: api/Persons/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeletePerson(Guid id)
        // {
        //     var person = await _bll.Persons.FirstOrDefaultAsync(id);
        //     if (person == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     _bll.Persons.Remove(person);
        //     await _context.SaveChangesAsync();
        //
        //     return NoContent();
        // }

    }
}
