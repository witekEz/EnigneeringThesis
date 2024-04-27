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
        public async Task<ActionResult<List<BodyTypeDTO>>> Get()
        {
            var bodyTypes=await _filterService.GetAll();
            return Ok(bodyTypes);
        }
    }
}
