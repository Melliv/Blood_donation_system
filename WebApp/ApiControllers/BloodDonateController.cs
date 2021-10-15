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
    public class BloodDonateController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly DTO.App.V1.Mappers.BloodDonateMapper _bloodDonateMapper;
        private readonly ILogger<AccountController> _logger;

        public BloodDonateController(IAppBLL bll, IMapper mapper, ILogger<AccountController> logger)
        {
            _bll = bll;
            _bloodDonateMapper = new DTO.App.V1.Mappers.BloodDonateMapper(mapper);
            _logger = logger;
        }

        /// <summary>
        /// Get all bloodDonates
        /// </summary>
        /// <returns>List of bloodDonates</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<DTO.App.V1.BloodDonate>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<DTO.App.V1.BloodDonate>>> GetBloodDonate()
        {
            return Ok((await _bll.BloodDonate.GetAllAsync()).Select(b => _bloodDonateMapper.Map(b)));
        }
        
        /// <summary>
        /// Get all person bloodDonates by person id
        /// </summary>
        /// <param name="personId">Donor id</param>
        /// <returns>List of person bloodDonates</returns>
        [HttpGet("personId={personId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<DTO.App.V1.BloodDonate>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<DTO.App.V1.BloodDonate>>> GetPersonBloodDonates(Guid personId)
        {
            return Ok((await _bll.BloodDonate.GetAllByPatientId(personId)).Select(b => _bloodDonateMapper.Map(b)));
        }

        /// <summary>
        /// Get bloodDonate by id
        /// </summary>
        /// <param name="id">BloodDonate id</param>
        /// <returns>BloodDonate</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DTO.App.V1.BloodDonate), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DTO.App.V1.BloodDonate>> GetBloodDonate(Guid id)
        {
            var bloodDonate = _bloodDonateMapper.Map(await _bll.BloodDonate.FirstOrDefaultAsync(id));
            if (bloodDonate == null) return BadRequest();
            return bloodDonate;
        }

        /// <summary>
        /// Update specific bloodDonate
        /// </summary>
        /// <param name="id">BloodDonate id</param>
        /// <param name="bloodDonate">New BloodDonate</param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutBloodDonate(Guid id, DTO.App.V1.BloodDonate bloodDonate)
        {
            var bloodDonateBLL = _bloodDonateMapper.Map(bloodDonate);
            if (id != bloodDonate.Id || bloodDonateBLL == null) return BadRequest();
            bloodDonateBLL.UpdatedAt = DateTime.Now;
            _bll.BloodDonate.Update(bloodDonateBLL);
            await _bll.SaveChangesAsync();
            return NoContent();
        }
        
        /// <summary>
        /// Insert new bloodDonate
        /// </summary>
        /// <param name="bloodDonate">New bloodDonate</param>
        /// <returns>BloodDonate</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DTO.App.V1.BloodDonate), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DTO.App.V1.BloodDonate>> PostBloodDonate(DTO.App.V1.BloodDonate bloodDonate)
        {
            var bloodDonateBLL = _bloodDonateMapper.Map(bloodDonate);
            if (bloodDonateBLL == null) return BadRequest();
            var BloodGroupId = await _bll.Persons.GetBloodGroupIdBySpecificPersonAsync(bloodDonate.DonorId);

            if (BloodGroupId == null) return BadRequest("Donor missing blood group!");

            bloodDonate.ExpireDate = DateTime.Now.AddMonths(6);
            bloodDonateBLL.CreateAt = DateTime.Now;
            bloodDonateBLL.UpdatedAt = DateTime.Now;
            bloodDonateBLL.BloodGroupId = (Guid) BloodGroupId;
            var bloodDonateDTO = _bloodDonateMapper.Map( _bll.BloodDonate.Add(bloodDonateBLL));
            if (bloodDonateDTO == null) return BadRequest();
            await _bll.SaveChangesAsync();
            return CreatedAtAction("GetBloodDonate", new { id = bloodDonateDTO.Id }, bloodDonateDTO);
        }

        /// <summary>
        /// Delete bloodDonate by id
        /// </summary>
        /// <param name="id">BloodDonate id</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBloodDonate(Guid id)
        {
            var bloodDonate = await _bll.BloodDonate.FirstOrDefaultAsync(id);
            if (bloodDonate == null) return BadRequest();
            _bll.BloodDonate.Remove(bloodDonate);
            await _bll.SaveChangesAsync();
            return NoContent();
        }
        
    }
}
