using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Read;
using UA.Model.DTOs.Update;
using UA.Services;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("api/brand/{brandId}/model")]
    [ApiController]
    public class ModelController : Controller
    {
        private readonly IModelService _modelService;
        public ModelController(IModelService modelService) { _modelService = modelService; }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser,User")]
        public async Task<IActionResult> Create([FromRoute]int brandId, [FromBody]CreateModelDTO modelDTO)
        {
            var modelId=await _modelService.Create(brandId, modelDTO);
            return Created($"api/{brandId}/model/{modelId}",null);
        }
        [HttpGet("{modelId}")]
        [AllowAnonymous]
        public async Task<ActionResult<ModelDTO>> Get([FromRoute]int brandId, [FromRoute]int modelId)
        {
            var model=await _modelService.GetById(brandId, modelId);
            return Ok(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<ModelDTO>>> Get([FromRoute] int brandId)
        {
            var model = await _modelService.GetAll(brandId);
            return Ok(model);
        }
        [HttpDelete("{modelId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute]int brandId, [FromRoute]int modelId) 
        {
            await _modelService.Delete(brandId, modelId);
            return NoContent(); 
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateModelDTO dto)
        {
            await _modelService.Update(id, dto);
            return NoContent();
        }
    }
}
