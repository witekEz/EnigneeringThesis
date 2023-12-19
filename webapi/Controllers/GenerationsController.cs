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
    [Route("api/[controller]")]
    [ApiController]
    public class GenerationsController : ControllerBase
    {
        private readonly IGenerationService _generationService;
        public GenerationsController(IGenerationService generationService) 
        {
           _generationService = generationService;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            var isDeleted= _generationService.Delete(id);
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();

        }

        [HttpPost]
        public ActionResult CreateGeneration([FromBody]CreateGenerationDTO dto)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var id=_generationService.Create(dto);
            return Created($"api/generations/{id}", null);
        }
        [HttpGet]
        public ActionResult<IEnumerable<GenerationDTO>> GetAll()
        {
            var generationsDTOs = _generationService.GetAll();
            return Ok(generationsDTOs);
        }
        [HttpGet("{id}")]
        public ActionResult<GenerationDTO> Get([FromRoute]int id)
        {
            var generation = _generationService.GetById(id);

            if(generation is null)
            {
                return NotFound();
            }

            return Ok(generation);
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody]UpdateGenerationDTO dto, [FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isUpdated = _generationService.Update(dto,id);
            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
