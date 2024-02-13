using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs;
using UA.Model.DTOs.Create;
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
        public ActionResult<DetailedInfoDTO> Get([FromRoute]int generationId)
        {
            var detailedInfo=_detailedInfoService.GetById(generationId);
            return Ok(detailedInfo);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Create([FromRoute]int generationId,[FromBody] CreateDetailedInfoDTO dto)
        {
            var id = _detailedInfoService.Create(generationId,dto);
            return Created($"api/generation/{generationId}/detailedinfo/{id}", null);
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute]int generationId)
        {
            _detailedInfoService.Delete(generationId);
            return NoContent();
        }
        [HttpPut]
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Update([FromRoute] int generationId,[FromBody] UpdateDetailedInfoDTO dto)
        {
            _detailedInfoService.Update(dto, generationId);
            return Ok();
        }
    }
}
