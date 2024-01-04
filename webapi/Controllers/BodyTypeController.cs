using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;
using UA.Services;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("api/generation/{generationId}/bodytype")]
    [ApiController]
    public class BodyTypeController : Controller
    {
        private readonly IBodyTypeService _bodyTypeService;
        public BodyTypeController(IBodyTypeService bodyTypeService)
        {
            _bodyTypeService = bodyTypeService;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<BodyTypeDTO>> Get([FromRoute]int generationId)
        {
            var bodyTypes = _bodyTypeService.GetAll(generationId);
            return Ok(bodyTypes);
        }
        [HttpGet("id")]
        [AllowAnonymous]
        public ActionResult<BodyTypeDTO> Get([FromRoute] int generationId, [FromRoute] int id)
        {
            var bodyType= _bodyTypeService.GetById(generationId,id);
            return Ok(bodyType);
        }
        [HttpPost]
        [Authorize(Roles ="Admin,SuperUser")]
        public ActionResult Create([FromRoute]int generationId, [FromBody]CreateBodyTypeDTO dto)
        {
            var id = _bodyTypeService.Create(generationId, dto);
            return Created($"api/generation/{generationId}/bodytype/{id}",null);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateBodyTypeDTO dto)
        {
            _bodyTypeService.Update(id, dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute] int generationId, [FromRoute] int id)
        {
            _bodyTypeService.Delete(generationId, id);
            return Ok();
        }
    }
}
