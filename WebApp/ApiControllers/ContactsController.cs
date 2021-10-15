using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.BLL.App;
using DAL.App.EF;
using DTO.App.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WebApp.ApiControllers.Identity;

namespace WebApp.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ContactsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly DTO.App.V1.Mappers.ContactMapper _contactMapper;
        private readonly ILogger<AccountController> _logger;

        public ContactsController(IAppBLL bll, IMapper mapper, ILogger<AccountController> logger)
        {
            _bll = bll;
            _contactMapper = new DTO.App.V1.Mappers.ContactMapper(mapper);
            _logger = logger;
        }
        
        /// <summary>
        ///  Get all contacts
        /// </summary>
        /// <returns>All Contacts</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<DTO.App.V1.Contact>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<DTO.App.V1.Contact>>> GetContact()
        {
            return Ok((await _bll.Contacts.GetAllAsync()).Select(c => _contactMapper.Map(c)));
        }
        
        /// <summary>
        /// Get contact by id
        /// </summary>
        /// <param name="id">Contact id</param>
        /// <returns>Contact</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DTO.App.V1.Contact), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Contact>> GetContact(Guid id)
        {
            var contact = _contactMapper.Map(await _bll.Contacts.FirstOrDefaultAsync(id));
            if (contact == null) return NotFound();
            return contact;
        }
        
        /// <summary>
        /// Get contact by specific person id
        /// </summary>
        /// <param name="id">Person id</param>
        /// <returns>All person contacts</returns>
        [HttpGet("person={id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<DTO.App.V1.Contact>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<DTO.App.V1.Contact>>> GetContactByPerson(Guid id)
        {
            var contact = (await _bll.Contacts.GetAllSpecificPersonAsync(id)).Select(c => _contactMapper.Map(c));
            return Ok(contact);
        }
        
        /// <summary>
        /// Update specific contact
        /// </summary>
        /// <param name="id">Contact id</param>
        /// <param name="contact">New contact</param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutContact(Guid id, Contact contact)
        {
            var contactBLL = _contactMapper.Map(contact);
            if (id != contact.Id || contactBLL == null) return BadRequest();
            contactBLL.UpdatedAt = DateTime.Now;
            _bll.Contacts.Update(contactBLL);
            await _bll.SaveChangesAsync();
            return NoContent();
        }
        
        /// <summary>
        /// Insert new contact
        /// </summary>
        /// <param name="contact">New Contact</param>
        /// <returns>Contact</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DTO.App.V1.Contact), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            var contactBLL = _contactMapper.Map(contact);
            if (contactBLL == null) return BadRequest();
            contactBLL.CreateAt = DateTime.Now;
            contactBLL.UpdatedAt = DateTime.Now;
            contactBLL = _bll.Contacts.Add(contactBLL);
            await _bll.SaveChangesAsync();
            var contactDTO = _contactMapper.Map(await _bll.Contacts.FirstOrDefaultAsync(contactBLL.Id));
            if (contactDTO == null) return BadRequest();
            return CreatedAtAction("GetContact", new { id = contactBLL.Id }, contactDTO);
        }
        
        /// <summary>
        /// Delete specific contact
        /// </summary>
        /// <param name="id">Contact id</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            var contact = await _bll.Contacts.FirstOrDefaultAsync(id);
            if (contact == null) return NotFound();
            _bll.Contacts.Remove(contact);
            await _bll.SaveChangesAsync();
            return NoContent();
        }
        
    }
}
