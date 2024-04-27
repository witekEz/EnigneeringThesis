using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;
using UA.Services.Interfaces;
using UA.Model.DTOs.Read;

namespace UA.WebAPI.Controllers
{
    [Route("/api/gearbox")]
    [ApiController]
    public class GearboxController : Controller
    {
        private readonly IGearboxService _gearboxService;
        public GearboxController(IGearboxService gearboxService)
        {
            _gearboxService = gearboxService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<GearboxDTO>>> Get()
        {
            var gearboxes = await _gearboxService.GetAll();
            return Ok(gearboxes);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GearboxDTO>> Get([FromRoute] int id)
        {
            var gearbox = await _gearboxService.GetById(id);
            return Ok(gearbox);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser,User")]
        public async Task<IActionResult> Create([FromBody] CreateGearboxDTO gearboxDTO)
        {
            var gearboxId = await _gearboxService.Create(gearboxDTO);
            return Created($"api/gearbox/{gearboxId}", null);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _gearboxService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGearboxDTO dto)
        {
            await _gearboxService.Update(id, dto);
            return NoContent();
        }
    }
}
