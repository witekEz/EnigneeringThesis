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
        public async Task<ActionResult<List<CategoryDTO>>> Get()
        {
            var categories=await _categoryService.GetAll();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryDTO>> Get([FromRoute]int id)
        {
            var category = await _categoryService.GetById(id);
            return Ok(category);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser,User")]
        public async Task<IActionResult> Create([FromBody]CreateCategoryDTO dto)
        {
            var categoryId = await _categoryService.Create(dto);
            return Created($"category/{categoryId}",null);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Update([FromRoute]int id,[FromBody]UpdateCategoryDTO dto)
        {
            await _categoryService.Update(id, dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _categoryService.Delete(id);
            return NoContent();
        }
    }
}
