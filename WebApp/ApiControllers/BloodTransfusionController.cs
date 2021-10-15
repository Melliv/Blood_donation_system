using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.BLL.App;
using DAL.App.EF;
using DTO.App.V1;
using Extensions.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApp.ApiControllers.Identity;

namespace WebApp.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BloodTransfusionController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly DTO.App.V1.Mappers.BloodTransfusionMapper _bloodTransfusionMapper;
        private readonly ILogger<AccountController> _logger;

        public BloodTransfusionController(IAppBLL bll, IMapper mapper, ILogger<AccountController> logger)
        {
            _bll = bll;
            _bloodTransfusionMapper = new DTO.App.V1.Mappers.BloodTransfusionMapper(mapper);
            _logger = logger;
        }
        
        /// <summary>
        /// Get all bloodTransfusions
        /// </summary>
        /// <returns>List of bloodTransfusions</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<DTO.App.V1.BloodTransfusion>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<BloodTransfusion>>> GetBloodTransfusion()
        {
            var bloodDonates = 
                (await _bll.BloodTransfusion.GetAllAsync()).Select(b => _bloodTransfusionMapper.Map(b)).ToList();
            return Ok(bloodDonates);
        }

        /// <summary>
        /// Get all person bloodTransfusions
        /// </summary>
        /// <param name="personId">Patient id</param>
        /// <returns>List of bloodTransfusions</returns>
        [HttpGet("personId={personId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<DTO.App.V1.BloodTransfusion>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<BloodTransfusion>>> GetPersonBloodTransfusion(Guid personId)
        {
            return Ok((await _bll.BloodTransfusion.GetAllByPatientId(personId)).Select(b => _bloodTransfusionMapper.Map(b)));
        }
        
        /// <summary>
        /// Get bloodTransfusion by id
        /// </summary>
        /// <param name="id">BloodTransfusion id</param>
        /// <returns>BloodTransfusion</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DTO.App.V1.BloodTransfusion), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<BloodTransfusion>> GetBloodTransfusion(Guid id)
        {
            var bloodTransfusion = _bloodTransfusionMapper.Map(await _bll.BloodTransfusion.FirstOrDefaultAsync(id));
            if (bloodTransfusion == null) return NotFound();
            return bloodTransfusion;
        }

        /// <summary>
        /// Update specific bloodTransfusion 
        /// </summary>
        /// <param name="id">BloodTransfusion id</param>
        /// <param name="bloodTransfusion">New bloodTransfusion</param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutBloodTransfusion(Guid id, BloodTransfusion bloodTransfusion)
        {
            var bloodTransfusionBLL = _bloodTransfusionMapper.Map(bloodTransfusion);
            if (id != bloodTransfusion.Id || bloodTransfusionBLL == null) return BadRequest();
            bloodTransfusionBLL.UpdatedAt = DateTime.Now;
            _bll.BloodTransfusion.Update(bloodTransfusionBLL);
            await _bll.SaveChangesAsync();
            return NoContent();
        }
        
        /// <summary>
        /// Insert new bloodTransfusion
        /// </summary>
        /// <param name="bloodTransfusion">New bloodTransfusions</param>
        /// <returns>BloodTransfusions</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<DTO.App.V1.BloodTransfusion>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<BloodTransfusion>> PostBloodTransfusion(BloodTransfusion bloodTransfusion)
        {
            var bloodTransfusionBLL = _bloodTransfusionMapper.Map(bloodTransfusion);
            if (bloodTransfusionBLL == null) return BadRequest();
            
            if (!_bll.BloodDonate.CanTransfuseBlood(User.GetUserId()!.Value, bloodTransfusionBLL!.Amount,
                bloodTransfusionBLL.BloodGroupId)) return BadRequest("Not enough blood to transfer!");
            
            bloodTransfusionBLL.CreateAt = DateTime.Now;
            bloodTransfusionBLL.UpdatedAt = DateTime.Now;
            var bloodTransfusionDTO = _bloodTransfusionMapper.Map(_bll.BloodTransfusion.Add(bloodTransfusionBLL));
            if (bloodTransfusionDTO == null) return BadRequest();

            await _bll.SaveChangesAsync();
            
            _bll.TransferableBlood.AddFixedAmount(bloodTransfusionDTO!.Amount, bloodTransfusionDTO.BloodGroupId, bloodTransfusionDTO.Id);
            
            return CreatedAtAction("GetBloodTransfusion", new { id = bloodTransfusionDTO.Id }, bloodTransfusionDTO);
        }

        // DELETE: api/BloodTransfusion/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteBloodTransfusion(Guid id)
        // {
        //     var bloodTransfusion = await _context.BloodTransfusion.FindAsync(id);
        //     if (bloodTransfusion == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     _context.BloodTransfusion.Remove(bloodTransfusion);
        //     await _context.SaveChangesAsync();
        //
        //     return NoContent();
        // }
        //
        // private bool BloodTransfusionExists(Guid id)
        // {
        //     return _context.BloodTransfusion.Any(e => e.Id == id);
        // }
    }
}
