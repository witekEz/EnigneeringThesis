﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UA.Model.DTOs.Create.Rate;
using UA.Model.DTOs.Read.Rate;
using UA.Model.DTOs.Update.Rate;
using UA.Services;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("api/gearbox/{gearboxId}/rate")]
    [ApiController]
    public class RateGearboxController : Controller
    {
        private readonly IRateGearboxService _rateGearboxService;
        public RateGearboxController(IRateGearboxService rateGearboxService)
        {
            _rateGearboxService = rateGearboxService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<AvgRateGearboxDTO>> Get([FromRoute] int gearboxId)
        {
            var avgRate = await _rateGearboxService.Get(gearboxId);
            return Ok(avgRate);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser,User")]
        public async Task<IActionResult> Create([FromBody] CreateRateGearboxDTO dto, [FromRoute] int gearboxId)
        {
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var rateId = await _rateGearboxService.Create(dto, gearboxId, userId);
            return Created($"api/geatbox/{gearboxId}/rate/{rateId}", null);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Update([FromBody] UpdateRateGearboxDTO dto, [FromRoute] int id, [FromRoute] int gearboxId)
        {
            await _rateGearboxService.Update(dto, gearboxId, id, User);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Delete([FromRoute] int gearboxId, [FromRoute] int id)
        {
            await _rateGearboxService.Delete(gearboxId, id, User);
            return NoContent();
        }
    }
}
