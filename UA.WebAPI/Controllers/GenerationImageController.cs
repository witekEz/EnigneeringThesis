using Microsoft.AspNetCore.Mvc;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("api/image")]
    public class GenerationImageController : Controller
    {
        private readonly IGenerationImageService _generationImageService;
        public GenerationImageController(IGenerationImageService generationImageService)
        {
            _generationImageService = generationImageService;
        }
        [HttpPost("{id}")]
        public ActionResult Upload([FromRoute]int id,[FromForm]IFormFile image)
        {
            _generationImageService.Upload(id,image);
            return Ok();
        }
    }
}
