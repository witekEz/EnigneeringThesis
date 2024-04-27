using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;
using UA.Services.Interfaces;
using UA.Model.DTOs.Read;

namespace UA.WebAPI.Controllers
{
    [Route("api/bodycolour")]
    [ApiController]
    public class BodyColourController : Controller
    {
        private readonly IBodyColourService _bodyColourService;
        public BodyColourController(IBodyColourService bodyColourService)
        {
            _bodyColourService = bodyColourService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<BodyColourDTO>>> Get()
        {
            var bodyColour = await _bodyColourService.GetAll();
            return Ok(bodyColour);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<BodyColourDTO>> Get([FromRoute] int id)
        {
            var bodyColour = await _bodyColourService.GetById(id);
            return Ok(bodyColour);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser,User")]
        public async Task<IActionResult> Create([FromBody] CreateBodyColourDTO dto)
        {
            var bodyColourId = await _bodyColourService.Create(dto);
            return Created($"api/bodycolour/{bodyColourId}", null);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _bodyColourService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBodyColourDTO dto)
        {
            await _bodyColourService.Update(id, dto);
            return NoContent();
        }
    }
}
