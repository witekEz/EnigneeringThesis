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
        public ActionResult<List<SuspensionDTO>> Get()
        {
            var suspension = _suspensionService.GetAll();
            return Ok(suspension);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<SuspensionDTO> Get([FromRoute] int id)
        {
            var suspension = _suspensionService.GetById(id);
            return Ok(suspension);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser,User")]
        public ActionResult Create([FromBody] CreateSuspensionDTO suspensionDTO)
        {
            var suspensionId = _suspensionService.Create(suspensionDTO);
            return Created($"api/suspension/{suspensionId}", null);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute] int id)
        {
            _suspensionService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateSuspensionDTO dto)
        {
            _suspensionService.Update(id, dto);
            return NoContent();
        }
    }
}
