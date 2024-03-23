using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UA.DAL.EF;
using UA.Model.Entities;
using UA.Model.DTOs.Create;
using UA.Services.Interfaces;
using UA.Model.DTOs.Update;
using Microsoft.AspNetCore.Authorization;
using UA.Model.DTOs.Read;

namespace UA.WebAPI.Controllers
{
    [Route("api/model/{modelId}/generation")]
    [ApiController]
    public class GenerationController : ControllerBase
    {
        private readonly IGenerationService _generationService;
        public GenerationController(IGenerationService generationService) 
        {
           _generationService = generationService;
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute]int modelId,[FromRoute]int id)
        {
            _generationService.Delete(modelId, id);
            return NoContent();
        }

        //[Route("api/brand/{brandId}/model/{modelId}/generation")]
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Create([FromRoute]int modelId,[FromBody]CreateGenerationDTO dto)
        {
            var id=_generationService.Create(modelId,dto);
            return Created($"api/brand/model/{modelId}/generation/{id}", null);
        }
        //[Route("api/model/{modelId}/generation")]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<GenerationDTO>> Get([FromRoute] int modelId)
        {
            var generationsDTOs = _generationService.GetAll(modelId);
            return Ok(generationsDTOs);
        }
        //[Route("api/model/{modelId}/generation")]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<GenerationDTO> Get([FromRoute] int modelId,[FromRoute]int id)
        {
            var generation = _generationService.GetById(modelId,id);

            return Ok(generation);
        }
        //[Route("api/model/{modelId}/generation")]
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Update([FromBody]UpdateGenerationDTO dto, [FromRoute]int id)
        {
             _generationService.Update(dto,id);
            
            return Ok();
        }
    }
}
