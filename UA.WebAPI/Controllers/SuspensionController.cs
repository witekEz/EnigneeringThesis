using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Read;
using UA.Model.DTOs.Update;
using UA.Services;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("api/suspension")]
    [ApiController]
    public class SuspensionController : Controller
    {
        private readonly ISuspensionService _suspensionService;
        public SuspensionController(ISuspensionService suspensionService) 
        {
            _suspensionService = suspensionService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<SuspensionDTO>>> Get()
        {
            var suspension = await _suspensionService.GetAll();
            return Ok(suspension);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<SuspensionDTO>> Get([FromRoute] int id)
        {
            var suspension = await _suspensionService.GetById(id);
            return Ok(suspension);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser,User")]
        public async Task<IActionResult> Create([FromBody] CreateSuspensionDTO suspensionDTO)
        {
            var suspensionId = await _suspensionService.Create(suspensionDTO);
            return Created($"api/suspension/{suspensionId}", null);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _suspensionService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSuspensionDTO dto)
        {
            await _suspensionService.Update(id, dto);
            return NoContent();
        }
    }
}
