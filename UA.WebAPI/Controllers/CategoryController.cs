using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Read;
using UA.Model.DTOs.Update;
using UA.Services;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService { get; set; }
        public CategoryController(ICategoryService categoryService){
            _categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<CategoryDTO>> Get()
        {
            var categories=_categoryService.GetAll();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<CategoryDTO> Get([FromRoute]int id)
        {
            var category = _categoryService.GetById(id);
            return Ok(category);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser,User")]
        public ActionResult Create([FromBody]CreateCategoryDTO dto)
        {
            var categoryId = _categoryService.Create(dto);
            return Created($"category/{categoryId}",null);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Update([FromRoute]int id,[FromBody]UpdateCategoryDTO dto)
        {
            _categoryService.Update(id,dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute] int id)
        {
            _categoryService.Delete(id);
            return NoContent();
        }
    }
}
