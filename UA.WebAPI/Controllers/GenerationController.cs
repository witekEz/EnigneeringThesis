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
        public async Task<IActionResult> Delete([FromRoute]int modelId,[FromRoute]int id)
        {
            await _generationService.Delete(modelId, id);
            return NoContent();
        }

        
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser,User")]
        public async Task<IActionResult> Create([FromRoute]int modelId,[FromBody]CreateGenerationDTO dto)
        {
            var id=await _generationService.Create(modelId, dto);
            return Ok(id);
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<GenerationDTO>>> Get([FromRoute] int modelId)
        {
            var generationsDTOs = await _generationService.GetAll(modelId);
            return Ok(generationsDTOs);
        }
        
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GenerationDTO>> Get([FromRoute] int modelId,[FromRoute]int id)
        {
            var generation = await _generationService.GetById(modelId,id);

            return Ok(generation);
        }
        
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Update([FromBody]UpdateGenerationDTO dto, [FromRoute]int id)
        {
             await _generationService.Update(dto, id);
            
            return Ok();
        }
    }
}
