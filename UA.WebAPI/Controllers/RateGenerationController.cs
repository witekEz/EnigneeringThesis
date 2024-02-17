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
        public ActionResult<AvgRateGenerationDTO> Get([FromRoute]int generationId) 
        {
            var avgRate=_rateGenerationService.Get(generationId);
            return Ok(avgRate);
        }
        [HttpPost]
        public ActionResult Create([FromBody] CreateRateGenerationDTO dto, [FromRoute] int generationId)
        {
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var rateId = _rateGenerationService.Create(dto,generationId,userId);
            return Created($"api/generation/{generationId}/rate/{rateId}",null);
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateRateGenerationDTO dto, [FromRoute] int id, [FromRoute] int generationId)
        {
            _rateGenerationService.Update(dto,generationId, id, User);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int generationId, [FromRoute] int id)
        {
            _rateGenerationService.Delete(generationId, id, User);
            return NoContent();
        }
    }
}
