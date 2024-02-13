using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;
using UA.Model.DTOs;
using UA.Services.Interfaces;

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
        public ActionResult<List<GearboxDTO>> Get()
        {
            var gearboxes = _gearboxService.GetAll();
            return Ok(gearboxes);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<GearboxDTO> Get([FromRoute] int id)
        {
            var gearbox = _gearboxService.GetById(id);
            return Ok(gearbox);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Create([FromBody] CreateGearboxDTO gearboxDTO)
        {
            var gearboxId = _gearboxService.Create(gearboxDTO);
            return Created($"api/gearbox/{gearboxId}", null);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Delete([FromRoute] int id)
        {
            _gearboxService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateGearboxDTO dto)
        {
            _gearboxService.Update(id, dto);
            return NoContent();
        }
    }
}
