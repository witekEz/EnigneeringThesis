using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandsService;
        public BrandController(IBrandService brandsService) { _brandsService = brandsService; }
        [HttpGet] 
        public ActionResult<IEnumerable<BrandDTO>> Get()
        {
            var brands= _brandsService.GetAll();
            return Ok(brands);
        }
        [HttpGet("{id}")]
        public ActionResult<BrandDTO> Get([FromRoute]int id)
        {
            var brand = _brandsService.GetById(id);
            return Ok(brand);
        }
        [HttpPost]
        public ActionResult Create([FromBody]CreateBrandDTO brandDTO)
        {
            var id = _brandsService.Create(brandDTO);
            return Created($"api/brands/{id}", null);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id) 
        {
            _brandsService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id,[FromBody]UpdateBrandDTO brandDTO)
        {
            _brandsService.Update(id,brandDTO);
            return Ok();
        }
    }
}
