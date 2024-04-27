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
        public async Task<ActionResult<List<DrivetrainDTO>>> Get()
        {
            var drivetrains=await _drivetrainService.GetAll();
            return Ok(drivetrains);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<DrivetrainDTO>> Get(int id)
        {
            var drivetrain = await _drivetrainService.GetById(id);
            return Ok(drivetrain);
        }
        [HttpPost]
        [Authorize(Roles ="Admin,SuperUser,User")]
        public async Task<IActionResult> Create([FromBody]CreateDrivetrainDTO dto)
        {
            var id= await _drivetrainService.Create(dto);
            return Created($"api/drivetrain/{id}",null);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await _drivetrainService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody]UpdateDrivetrainDTO dto)
        {
            await _drivetrainService.Update(id,dto);
            return Ok();
        }
    }
}
