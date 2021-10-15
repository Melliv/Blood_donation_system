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
    public class BloodGroupController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly DTO.App.V1.Mappers.BloodGroupMapper _bloodGroupMapper;
        private readonly ILogger<AccountController> _logger;

        public BloodGroupController(IAppBLL bll, IMapper mapper, ILogger<AccountController> logger)
        {
            _bll = bll;
            _bloodGroupMapper = new DTO.App.V1.Mappers.BloodGroupMapper(mapper);
            _logger = logger;
        }

        /// <summary>
        /// Get all bloodGroups
        /// </summary>
        /// <returns>List of bloodGroups</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<DTO.App.V1.BloodGroup>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<DTO.App.V1.BloodGroup>>> GetBloodGroup()
        {
            return Ok((await _bll.BloodGroup.GetAllAsync()).Select(b => _bloodGroupMapper.Map(b)));
        }

        /// <summary>
        /// Get bloodGroup by id
        /// </summary>
        /// <param name="id">BloodGroup id</param>
        /// <returns>BloodGroup</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DTO.App.V1.BloodGroup), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DTO.App.V1.BloodGroup>> GetBloodGroup(Guid id)
        {
            var bloodGroup = _bloodGroupMapper.Map(await _bll.BloodGroup.FirstOrDefaultAsync(id));
            if (bloodGroup == null) return NotFound();
            return bloodGroup;
        }

        /// <summary>
        /// Update specific bloodGroup
        /// </summary>
        /// <param name="id">BloodGroup id</param>
        /// <param name="bloodGroup">New bloodGroup</param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutBloodGroup(Guid id, DTO.App.V1.BloodGroup bloodGroup)
        {
            var bloodGroupBLL = _bloodGroupMapper.Map(bloodGroup);
            if (id != bloodGroup.Id || bloodGroupBLL == null)  return BadRequest();
            bloodGroupBLL.UpdatedAt = DateTime.Now;
            _bll.BloodGroup.Update(bloodGroupBLL);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Insert new bloodGroup
        /// </summary>
        /// <param name="bloodGroup">New bloodGroup</param>
        /// <returns>BloodGroup</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DTO.App.V1.BloodGroup), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DTO.App.V1.BloodGroup>> PostBloodGroup(DTO.App.V1.BloodGroup bloodGroup)
        {
            var bloodGroupBLL = _bloodGroupMapper.Map(bloodGroup);
            if (bloodGroupBLL == null)  return BadRequest();
            bloodGroupBLL.CreateAt = DateTime.Now;
            bloodGroupBLL.UpdatedAt = DateTime.Now;
            _bll.BloodGroup.Add(bloodGroupBLL);
            await _bll.SaveChangesAsync();
            return CreatedAtAction("GetBloodGroup", new { id = bloodGroup.Id }, bloodGroup);
        }

        /// <summary>
        /// Delete bloodGroup by id
        /// </summary>
        /// <param name="id">BloodGroup id</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBloodGroup(Guid id)
        {
            var bloodGroup = await _bll.BloodGroup.FirstOrDefaultAsync(id);
            if (bloodGroup == null) return NotFound();
            _bll.BloodGroup.Remove(bloodGroup);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

    }
}
