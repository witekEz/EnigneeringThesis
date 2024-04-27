using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UA.Model.DTOs.Create.Rate;
using UA.Model.DTOs.Read.Rate;
using UA.Model.DTOs.Update.Rate;
using UA.Services;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("api/engine/{engineId}/rate")]
    [ApiController]
    public class RateEngineController : Controller
    {
        private readonly IRateEngineService _rateEngineService;
        public RateEngineController(IRateEngineService rateEngineService)
        {
            _rateEngineService = rateEngineService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<AvgRateEngineDTO>> Get([FromRoute] int engineId)
        {
            var avgRate = await _rateEngineService.Get(engineId);
            return Ok(avgRate);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser,User")]
        public async Task<IActionResult> Create([FromBody] CreateRateEngineDTO dto, [FromRoute] int engineId)
        {
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var rateId = await _rateEngineService.Create(dto, engineId, userId);
            return Created($"api/engine/{engineId}/rate/{rateId}", null);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Update([FromBody] UpdateRateEngineDTO dto, [FromRoute] int id, [FromRoute] int engineId)
        {
            await _rateEngineService.Update(dto, engineId, id, User);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Delete([FromRoute] int engineId, [FromRoute] int id)
        {
            await _rateEngineService.Delete(engineId, id, User);
            return NoContent();
        }
    }
}
