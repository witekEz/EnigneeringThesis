using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs.Read;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("api/bodytype")]
    [ApiController]
    public class BodyTypeController : Controller
    {
        private IBodyTypeService _filterService;
        public BodyTypeController(IBodyTypeService filterService)
        {
            _filterService = filterService;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<BodyTypeDTO>> Get()
        {
            var bodyTypes=_filterService.GetAll();
            return Ok(bodyTypes);
        }
    }
}
