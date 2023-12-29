using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("api/bodytype")]
    [ApiController]
    public class BodyTypeController : Controller
    {
        private readonly IBodyTypeService _bodyTypeService;
        public BodyTypeController(IBodyTypeService bodyTypeService)
        {
            _bodyTypeService = bodyTypeService;
        }
        [HttpGet]
        public ActionResult<List<BodyTypeDTO>>Get()
        {
            var bodyTypes = _bodyTypeService.GetAll();
            return Ok(bodyTypes);
        }
    }
}
