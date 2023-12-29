using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UA.DAL.EF;
using UA.Model.DTOs;
using UA.Model.Entities;
using UA.Model.DTOs.Create;
using UA.Services.Interfaces;
using UA.Model.DTOs.Update;

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
        public ActionResult Delete([FromRoute]int modelId,[FromRoute]int id)
        {
            _generationService.DeleteById(modelId, id);
            return NoContent();
        }

        [HttpPost]
        public ActionResult Create([FromRoute]int modelId,[FromBody]CreateGenerationDTO dto)
        {
            var id=_generationService.Create(modelId,dto);
            return Created($"api/brand/model/{modelId}/generation/{id}", null);
        }
        [HttpGet]
        public ActionResult<List<GenerationDTO>> Get([FromRoute] int modelId)
        {
            var generationsDTOs = _generationService.GetAll(modelId);
            return Ok(generationsDTOs);
        }
        [HttpGet("{generationId}")]
        public ActionResult<GenerationDTO> Get([FromRoute] int modelId,[FromRoute]int generationId)
        {
            var generation = _generationService.GetById(modelId,generationId);

            return Ok(generation);
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody]UpdateGenerationDTO dto, [FromRoute]int id)
        {
             _generationService.Update(dto,id);
            
            return Ok();
        }
    }
}
