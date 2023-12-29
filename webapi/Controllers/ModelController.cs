using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs;
using UA.Model.DTOs.Create;
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
        public ActionResult Create([FromRoute]int brandId, [FromBody]CreateModelDTO modelDTO)
        {
            var modelId=_modelService.Create(brandId, modelDTO);
            return Created($"api/{brandId}/model/{modelId}",null);
        }
        [HttpGet("{modelId}")]
        public ActionResult<ModelDTO> Get([FromRoute]int brandId, [FromRoute]int modelId)
        {
            var model=_modelService.GetById(brandId, modelId);
            return Ok(model);
        }
        [HttpGet]
        public ActionResult<List<ModelDTO>> Get([FromRoute] int brandId)
        {
            var model = _modelService.GetAll(brandId);
            return Ok(model);
        }
        [HttpDelete("{modelId}")]
        public ActionResult Delete([FromRoute]int brandId, [FromRoute]int modelId) 
        {
            _modelService.DeleteById(brandId,modelId);
            return NoContent(); 
        }
    }
}
