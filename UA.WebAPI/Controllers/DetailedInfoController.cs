using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Read;
using UA.Model.DTOs.Update;
using UA.Model.Entities;
using UA.Services;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("/api/generation/{generationId}/detailedinfo")]
    [ApiController]
    public class DetailedInfoController : Controller
    {
        private readonly IDetailedInfoService _detailedInfoService;
        public DetailedInfoController(IDetailedInfoService detailedInfoService) 
        {
            _detailedInfoService = detailedInfoService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<DetailedInfoDTO>> Get([FromRoute]int generationId)
        {
            var detailedInfo=await _detailedInfoService.GetById(generationId);
            return Ok(detailedInfo);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser,User")]
        public async Task<IActionResult> Create([FromRoute]int generationId,[FromBody] CreateDetailedInfoDTO dto)
        {
            var id = await _detailedInfoService.Create(generationId, dto);
            return Created($"api/generation/{generationId}/detailedinfo/{id}", null);
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute]int generationId)
        {
            await _detailedInfoService.Delete(generationId);
            return NoContent();
        }
        [HttpPut]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Update([FromRoute] int generationId,[FromBody] UpdateDetailedInfoDTO dto)
        {
            await _detailedInfoService.Update(dto, generationId);
            return Ok();
        }
    }
}
