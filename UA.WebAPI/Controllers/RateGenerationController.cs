using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UA.Model.DTOs.Create.Rate;
using UA.Model.DTOs.Read.Rate;
using UA.Model.DTOs.Update.Rate;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("api/generation/{generationId}/rate")]
    [ApiController]
    public class RateGenerationController : Controller
    {
        private readonly IRateGenerationService _rateGenerationService;
        public RateGenerationController(IRateGenerationService rateGenerationService)
        {
            _rateGenerationService = rateGenerationService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<AvgRateGenerationDTO>> Get([FromRoute]int generationId) 
        {
            var avgRate=await _rateGenerationService.Get(generationId);
            return Ok(avgRate);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser,User")]
        public async Task<IActionResult> Create([FromBody] CreateRateGenerationDTO dto, [FromRoute] int generationId)
        {
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var rateId = await _rateGenerationService.Create(dto, generationId, userId);
            return Created($"api/generation/{generationId}/rate/{rateId}",null);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Update([FromBody] UpdateRateGenerationDTO dto, [FromRoute] int id, [FromRoute] int generationId)
        {
            await _rateGenerationService.Update(dto, generationId, id, User);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Delete([FromRoute] int generationId, [FromRoute] int id)
        {
            await _rateGenerationService.Delete(generationId, id, User);
            return NoContent();
        }
    }
}
