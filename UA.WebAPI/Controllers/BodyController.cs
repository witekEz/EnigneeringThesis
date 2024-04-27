using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Read;
using UA.Model.DTOs.Update;
using UA.Services;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("api/generation/{generationId}/body")]
    [ApiController]
    public class BodyController : Controller
    {
        private readonly IBodyService _bodyService;
        public BodyController(IBodyService bodyService)
        {
            _bodyService = bodyService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<BodyDTO>>> Get([FromRoute]int generationId)
        {
            var bodies = await _bodyService.GetAll(generationId);
            return Ok(bodies);
        }
        [HttpGet("id")]
        [AllowAnonymous]
        public async Task<ActionResult<BodyDTO>> Get([FromRoute] int generationId, [FromRoute] int id)
        {
            var body= await _bodyService.GetById(generationId,id);
            return Ok(body);
        }
        [HttpPost]
        [Authorize(Roles ="Admin,SuperUser,User")]
        public async Task<IActionResult> Create([FromRoute]int generationId, [FromBody]CreateBodyDTO dto)
        {
            var id = await _bodyService.Create(generationId, dto);
            return Created($"api/generation/{generationId}/body/{id}",null);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBodyDTO dto)
        {
            await _bodyService.Update(id, dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int generationId, [FromRoute] int id)
        {
            await _bodyService.Delete(generationId, id);
            return Ok();
        }
    }
}
