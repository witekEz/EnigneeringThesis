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
        public ActionResult<List<EngineDTO>> Get()
        {
            var engines = _brakeService.GetAll();
            return Ok(engines);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<EngineDTO> Get([FromRoute] int id)
        {
            var engine = _brakeService.GetById(id);
            return Ok(engine);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Create([FromBody] CreateBrakeDTO brakeDTO)
        {
            var brakeId = _brakeService.Create(brakeDTO);
            return Created($"api/brake/{brakeId}", null);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute] int id)
        {
            _brakeService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateBrakeDTO dto)
        {
            _brakeService.Update(id, dto);
            return NoContent();
        }
    }
}
