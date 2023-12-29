using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs;
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
        public ActionResult<List<DrivetrainDTO>> Get()
        {
            var drivetrain=_drivetrainService.GetAll();
            return Ok(drivetrain);
        }
    }
}
