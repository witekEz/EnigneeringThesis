using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;
using UA.Services.Interfaces;
using UA.Model.DTOs.Read;

namespace UA.WebAPI.Controllers
{
    [Route("api/brake")]
    [ApiController]
    public class BrakeController : Controller
    {
        private readonly IBrakeService _brakeService;
        public BrakeController(IBrakeService brakeService)
        {
            _brakeService = brakeService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<EngineDTO>>> Get()
        {
            var engines = await _brakeService.GetAll();
            return Ok(engines);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<EngineDTO>> Get([FromRoute] int id)
        {
            var engine = await _brakeService.GetById(id);
            return Ok(engine);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser,User")]
        public async Task<IActionResult> Create([FromBody] CreateBrakeDTO brakeDTO)
        {
            var brakeId = await _brakeService.Create(brakeDTO);
            return Created($"api/brake/{brakeId}", null);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _brakeService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBrakeDTO dto)
        {
            await _brakeService.Update(id, dto);
            return NoContent();
        }
    }
}
