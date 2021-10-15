using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain.App;
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
    public class ContactTypesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly DTO.App.V1.Mappers.ContactTypeMapper _contactTypeMapper;
        private readonly ILogger<AccountController> _logger;
        
        public ContactTypesController(IAppBLL bll, IMapper mapper, ILogger<AccountController> logger)
        {
            _bll = bll;
            _contactTypeMapper = new DTO.App.V1.Mappers.ContactTypeMapper(mapper);
            _logger = logger;
        }
        
        /// <summary>
        /// Get all contactTypes
        /// </summary>
        /// <returns>List of contactTypes</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<DTO.App.V1.ContactType>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<DTO.App.V1.ContactType>>> GetContactType()
        {
            return Ok((await _bll.ContactTypes.GetAllAsync()).Select(c => _contactTypeMapper.Map(c)));
        }
        
        /// <summary>
        /// Get contactType by id
        /// </summary>
        /// <param name="id">ContactType id</param>
        /// <returns>ContactType</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DTO.App.V1.ContactType), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DTO.App.V1.ContactType>> GetContactType(Guid id)
        {
            var contactType = _contactTypeMapper.Map(await _bll.ContactTypes.FirstOrDefaultAsync(id));
            if (contactType == null) return NotFound();
            return contactType;
        }
        
        /// <summary>
        /// Update specific contactType
        /// </summary>
        /// <param name="id">ContactType id</param>
        /// <param name="contactType">ContactType</param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutContactType(Guid id, DTO.App.V1.ContactType contactType)
        {
            var contactTypeBLL = _contactTypeMapper.Map(contactType);
            if (id != contactType.Id || contactTypeBLL == null) return BadRequest();
            contactTypeBLL.UpdatedAt = DateTime.Now;
            _bll.ContactTypes.Update(contactTypeBLL);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Insert new contactType
        /// </summary>
        /// <param name="contactType">New contactType</param>
        /// <returns>ContactType</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DTO.App.V1.ContactType), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<ContactType>> PostContactType(DTO.App.V1.ContactType contactType)
        {
            var contactTypeDTO = _contactTypeMapper.Map(contactType);
            if (contactTypeDTO == null) return BadRequest();
            contactTypeDTO.CreateAt = DateTime.Now;
            contactTypeDTO.UpdatedAt = DateTime.Now;
            _bll.ContactTypes.Add(contactTypeDTO);
            await _bll.SaveChangesAsync();
            return CreatedAtAction("GetContactType", new { id = contactType.Id }, contactType);
        }

        /// <summary>
        /// Delete contactType by id
        /// </summary>
        /// <param name="id">ContactType id</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteContactType(Guid id)
        {
            var contactType = await _bll.ContactTypes.FirstOrDefaultAsync(id);
            if (contactType == null) return NotFound();
            _bll.ContactTypes.Remove(contactType);
            await _bll.SaveChangesAsync();
            return NoContent();
        }
        
    }
}
