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
        public ActionResult<List<EngineDTO>> Get()
        {
            var engines = _engineService.GetAll();
            return Ok(engines);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<EngineDTO> Get([FromRoute]int id) 
        {
            var engine=_engineService.GetById(id);
            return Ok(engine);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser,User")]
        public ActionResult Create([FromBody]CreateEngineDTO dto)
        {
            var engineId=_engineService.Create( dto);
            return Created($"api/engine/{engineId}", null);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute]int id)
        {
            _engineService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Update([FromRoute] int id, [FromBody]UpdateEngineDTO dto)
        {
            _engineService.Update(id,dto);
            return NoContent();
        }
    }
}
