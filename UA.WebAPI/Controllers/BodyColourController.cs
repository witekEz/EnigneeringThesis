using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;
using UA.Model.DTOs;
using UA.Services.Interfaces;

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
        public ActionResult<List<BodyColourDTO>> Get()
        {
            var bodyColour = _bodyColourService.GetAll();
            return Ok(bodyColour);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<BodyColourDTO> Get([FromRoute] int id)
        {
            var bodyColour = _bodyColourService.GetById(id);
            return Ok(bodyColour);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Create([FromBody] CreateBodyColourDTO dto)
        {
            var bodyColourId = _bodyColourService.Create(dto);
            return Created($"api/bodycolour/{bodyColourId}", null);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute] int id)
        {
            _bodyColourService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateBodyColourDTO dto)
        {
            _bodyColourService.Update(id, dto);
            return NoContent();
        }
    }
}
