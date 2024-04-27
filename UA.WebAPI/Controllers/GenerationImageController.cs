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
        public async Task<IActionResult> Upload([FromRoute]int id,[FromForm]IFormFile image)
        {
            await _generationImageService.Upload(id, image);
            return Ok();
        }
    }
}
