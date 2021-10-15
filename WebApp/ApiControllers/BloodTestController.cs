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
using DTO.App.V1.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApp.ApiControllers.Identity;

namespace WebApp.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BloodTestController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly DTO.App.V1.Mappers.BloodTestMapper _bloodTestMapper;
        private readonly ILogger<AccountController> _logger;

        public BloodTestController(IAppBLL bll, IMapper mapper, ILogger<AccountController> logger)
        {
            _bll = bll;
            _bloodTestMapper = new DTO.App.V1.Mappers.BloodTestMapper(mapper);
            _logger = logger;
        }

        /// <summary>
        /// Get all bloodTests
        /// </summary>
        /// <returns>List of bloodTests</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<DTO.App.V1.BloodTest>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<DTO.App.V1.BloodTest>>> GetBloodTest()
        {
            return Ok((await _bll.BloodTest.GetAllAsync()).Select(b => _bloodTestMapper.Map(b)));
        }
        
        /// <summary>
        /// Get all person bloodTests by person id
        /// </summary>
        /// <param name="personId">Patient id</param>
        /// <returns>List of person bloodTests</returns>
        [HttpGet("personId={personId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<DTO.App.V1.BloodTest>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<DTO.App.V1.BloodTest>>> GetPersonBloodTest(Guid personId)
        {
            return Ok((await _bll.BloodTest.GetAllByPatientId(personId)).Select(b => _bloodTestMapper.Map(b)));
        }
        
        /// <summary>
        /// Get all bloodTests, but only with id and overviewData 
        /// </summary>
        /// <returns>List of bloodTests</returns>
        [HttpGet("minimum")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<DTO.App.V1.BloodTest>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<DTO.App.V1.BloodTest>>> GetBloodTestMin()
        {
            return Ok((await _bll.BloodTest.GetAllAsync()).Select(BloodTestMapper.ToDTOCreate));
        }

        /// <summary>
        /// Get specific bloodTest
        /// </summary>
        /// <param name="id">BloodTest id</param>
        /// <returns>BloodTest</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DTO.App.V1.BloodTest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DTO.App.V1.BloodTest>> GetBloodTest(Guid id)
        {
            var bloodTest = _bloodTestMapper.Map(await _bll.BloodTest.FirstOrDefaultAsync(id));
            if (bloodTest == null) return NotFound();
            return bloodTest;
        }

        /// <summary>
        /// Update specific bloodTest
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bloodTest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutBloodTest(Guid id, DTO.App.V1.BloodTest bloodTest)
        {
            var bloodTestBLL = _bloodTestMapper.Map(bloodTest);
            if (id != bloodTest.Id || bloodTestBLL == null) return BadRequest();
            bloodTestBLL.UpdatedAt = DateTime.Now;
            _bll.BloodTest.Update(bloodTestBLL);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Insert new bloodTest
        /// </summary>
        /// <param name="bloodTest">New bloodTest</param>
        /// <returns>BloodTest</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DTO.App.V1.BloodTest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DTO.App.V1.BloodTest>> PostBloodTest(DTO.App.V1.BloodTest bloodTest)
        {
            var bloodTestBLL = _bloodTestMapper.Map(bloodTest);
            if (bloodTestBLL == null) return BadRequest();
            bloodTestBLL.CreateAt = DateTime.Now;
            bloodTestBLL.UpdatedAt = DateTime.Now;
            var bloodTestDTO = _bloodTestMapper.Map(_bll.BloodTest.Add(bloodTestBLL)) ;
            if (bloodTestDTO == null) return BadRequest();
            
            await _bll.SaveChangesAsync();
            await _bll.Persons.PutBloodGroupIfNeeded((Guid) bloodTestDTO!.DonorId!, (Guid) bloodTestDTO!.BloodGroupId!);
            
            return CreatedAtAction("GetBloodTest", new { id = bloodTestDTO.Id }, bloodTestDTO);
        }

        /// <summary>
        /// Delete specific bloodTest
        /// </summary>
        /// <param name="id">BloodTest id</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBloodTest(Guid id)
        {
            var bloodTest = await _bll.BloodTest.FirstOrDefaultAsync(id);
            if (bloodTest == null) return NotFound();
            _bll.BloodTest.Remove(bloodTest);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

    }
}
