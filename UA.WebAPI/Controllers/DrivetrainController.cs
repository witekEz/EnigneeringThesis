using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Read;
using UA.Model.DTOs.Update;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("api/drivetrain")]
    [ApiController]
    public class DrivetrainController : Controller
    {
        private readonly IDrivetrainService _drivetrainService;
        public DrivetrainController(IDrivetrainService drivetrainService)
        {
            _drivetrainService = drivetrainService;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<DrivetrainDTO>> Get()
        {
            var drivetrains=_drivetrainService.GetAll();
            return Ok(drivetrains);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<DrivetrainDTO> Get(int id)
        {
            var drivetrain = _drivetrainService.GetById(id);
            return Ok(drivetrain);
        }
        [HttpPost]
        [Authorize(Roles ="Admin,SuperUser,User")]
        public ActionResult Create([FromBody]CreateDrivetrainDTO dto)
        {
            var id= _drivetrainService.Create(dto);
            return Created($"api/drivetrain/{id}",null);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute]int id)
        {
            _drivetrainService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Update([FromRoute] int id, [FromBody]UpdateDrivetrainDTO dto)
        {
            _drivetrainService.Update(id,dto);
            return Ok();
        }
    }
}
