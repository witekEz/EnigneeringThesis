using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("api/home")]
    [ApiController]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        public HomeController(IHomeService homeService) {
            _homeService = homeService;
        }
        [HttpGet]
        
        public ActionResult<List<GenerationDTO>> Get()
        {
            var generations=_homeService.GetAll();
            return Ok(generations);
        }
        [HttpGet("{id}")]
        public ActionResult<GenerationDTO> Get(int id)
        {
            var generation = _homeService.GetById(id);
            return Ok(generation);
        }
    }
}
