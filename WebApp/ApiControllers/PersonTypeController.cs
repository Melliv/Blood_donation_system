using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.BLL.App;
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
    public class PersonTypeController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly DTO.App.V1.Mappers.PersonTypeMapper _personTypeMapper;
        private readonly ILogger<AccountController> _logger;

        public PersonTypeController(IAppBLL bll, IMapper mapper, ILogger<AccountController> logger)
        {
            _bll = bll;
            _personTypeMapper = new DTO.App.V1.Mappers.PersonTypeMapper(mapper);
            _logger = logger;
        }

        /// <summary>
        /// Get all personTypes
        /// </summary>
        /// <returns>List of personTypes</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<DTO.App.V1.PersonType>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<DTO.App.V1.PersonType>>> GetPersonType()
        {
            return Ok((await _bll.PersonType.GetAllAsync()).Select(p => _personTypeMapper.Map(p)));
        }

        /// <summary>
        /// Get personType by id
        /// </summary>
        /// <param name="id">PersonType id</param>
        /// <returns>PersonType</returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DTO.App.V1.PersonType), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DTO.App.V1.PersonType>> GetPersonType(Guid id)
        {
            var personType = _personTypeMapper.Map(await _bll.PersonType.FirstOrDefaultAsync(id));
            if (personType == null) return NotFound();
            return personType;
        }

        /// <summary>
        /// Update specific personType
        /// </summary>
        /// <param name="id">PersonType id</param>
        /// <param name="personType">New personType</param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutPersonType(Guid id, DTO.App.V1.PersonType personType)
        {
            var contactDTO = _personTypeMapper.Map(personType);
            if (id != personType.Id || contactDTO == null) return BadRequest();
            contactDTO.UpdatedAt = DateTime.Now;
            _bll.PersonType.Update(contactDTO);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Insert new personType
        /// </summary>
        /// <param name="personType">New personType</param>
        /// <returns>PersonType</returns>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DTO.App.V1.PersonType), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DTO.App.V1.PersonType>> PostPersonType(DTO.App.V1.PersonType personType)
        {
            var personTypeBLL = _personTypeMapper.Map(personType);
            if (personTypeBLL == null) return BadRequest();
            personTypeBLL.CreateAt = DateTime.Now;
            personTypeBLL.UpdatedAt = DateTime.Now;
            var personTypeDTO = _personTypeMapper.Map(_bll.PersonType.Add(personTypeBLL));
            if (personTypeDTO == null) return BadRequest();
            await _bll.SaveChangesAsync();
            return CreatedAtAction("GetPersonType", new { id = personTypeDTO.Id }, personTypeDTO);
        }

        /// <summary>
        /// Delete personType by id
        /// </summary>
        /// <param name="id">PersonType Id</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePersonType(Guid id)
        {
            var personType = await _bll.PersonType.FirstOrDefaultAsync(id);
            if (personType == null) return NotFound();
            _bll.PersonType.Remove(personType);
            await _bll.SaveChangesAsync();
            return NoContent();
        }
        
    }
}
