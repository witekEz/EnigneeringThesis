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
        public ActionResult<AvgRateEngineDTO> Get([FromRoute] int engineId)
        {
            var avgRate = _rateEngineService.Get(engineId);
            return Ok(avgRate);
        }
        [HttpPost]
        public ActionResult Create([FromBody] CreateRateEngineDTO dto, [FromRoute] int engineId)
        {
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var rateId = _rateEngineService.Create(dto, engineId, userId);
            return Created($"api/engine/{engineId}/rate/{rateId}", null);
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateRateEngineDTO dto, [FromRoute] int id, [FromRoute] int engineId)
        {
            _rateEngineService.Update(dto, engineId, id, User);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int engineId, [FromRoute] int id)
        {
            _rateEngineService.Delete(engineId, id, User);
            return NoContent();
        }
    }
}
