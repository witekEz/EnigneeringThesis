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
        public ActionResult<List<BodyDTO>> Get([FromRoute]int generationId)
        {
            var bodies = _bodyService.GetAll(generationId);
            return Ok(bodies);
        }
        [HttpGet("id")]
        [AllowAnonymous]
        public ActionResult<BodyDTO> Get([FromRoute] int generationId, [FromRoute] int id)
        {
            var body= _bodyService.GetById(generationId,id);
            return Ok(body);
        }
        [HttpPost]
        [Authorize(Roles ="Admin,SuperUser")]
        public ActionResult Create([FromRoute]int generationId, [FromBody]CreateBodyDTO dto)
        {
            var id = _bodyService.Create(generationId, dto);
            return Created($"api/generation/{generationId}/body/{id}",null);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateBodyDTO dto)
        {
            _bodyService.Update(id, dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute] int generationId, [FromRoute] int id)
        {
            _bodyService.Delete(generationId, id);
            return Ok();
        }
    }
}
