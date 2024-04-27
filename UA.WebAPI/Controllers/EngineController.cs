using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Read;
using UA.Model.DTOs.Update;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("/api/engine")]
    [ApiController]
    public class EngineController : Controller
    {
        private readonly IEngineService _engineService;
        public EngineController(IEngineService engineService) 
        {
            _engineService = engineService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<EngineDTO>>> Get()
        {
            var engines = await _engineService.GetAll();
            return Ok(engines);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<EngineDTO>> Get([FromRoute]int id) 
        {
            var engine=await _engineService.GetById(id);
            return Ok(engine);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser,User")]
        public async Task<IActionResult> Create([FromBody]CreateEngineDTO dto)
        {
            var engineId=await _engineService.Create(dto);
            return Created($"api/engine/{engineId}", null);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await _engineService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody]UpdateEngineDTO dto)
        {
            await _engineService.Update(id, dto);
            return NoContent();
        }
    }
}
