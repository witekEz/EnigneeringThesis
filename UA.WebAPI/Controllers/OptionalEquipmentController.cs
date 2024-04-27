using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;
using UA.Services.Interfaces;
using UA.Model.DTOs.Read;

namespace UA.WebAPI.Controllers
{
    [Route("/api/generation/{generationId}/optionalequipment")]
    [ApiController]
    public class OptionalEquipmentController : Controller
    {

        private readonly IOptionalEquipmentService _optionalEquipmentService;
        public OptionalEquipmentController(IOptionalEquipmentService optionalEquipmentService)
        {
            _optionalEquipmentService = optionalEquipmentService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<OptionalEquipmentDTO>> Get([FromRoute] int generationId)
        {
            var optionalEquipment = await _optionalEquipmentService.GetById(generationId);
            return Ok(optionalEquipment);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser,User")]
        public async Task<IActionResult> Create([FromRoute] int generationId, [FromBody] CreateOptionalEquipmentDTO dto)
        {
            var id = await _optionalEquipmentService.Create(generationId, dto);
            return Created($"api/generation/{generationId}/optionalequipment/{id}", null);
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int generationId)
        {
            await _optionalEquipmentService.Delete(generationId);
            return NoContent();
        }
        [HttpPut]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Update([FromRoute] int generationId, [FromBody] UpdateOptionalEquipmentDTO dto)
        {
            await _optionalEquipmentService.Update(dto, generationId);
            return Ok();
        }
    }
}
