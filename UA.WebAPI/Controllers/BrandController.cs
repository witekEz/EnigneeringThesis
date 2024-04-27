using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Read;
using UA.Model.DTOs.Update;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("api/brand")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService) 
        { 
            _brandService = brandService; 
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<BrandDTO>>> Get()
        {
            var brands= await _brandService.GetAll();
            return Ok(brands);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<BrandDTO>> Get([FromRoute]int id)
        {
            var brand = await _brandService.GetById(id);
            return Ok(brand);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser,User")]
        public async Task<IActionResult> Create([FromBody]CreateBrandDTO brandDTO)
        {
            var id = await _brandService.Create(brandDTO);
            return Created($"api/brand/{id}", null);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute]int id) 
        {
            await _brandService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody]UpdateBrandDTO brandDTO)
        {
            await _brandService.Update(id, brandDTO);
            return Ok();
        }
    }
}
