﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs.Read;
using UA.Model.Queries;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("api/home")]
    [ApiController]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        public HomeController(IHomeService homeService) {
            _homeService = homeService;
        }

        [HttpGet]
        public ActionResult<PageResult<GenerationDTO>> Get([FromQuery]GenerationQuery query)
        {
            var generations=_homeService.GetAll(query);
            return Ok(generations);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GenerationDTO>> Get(int id)
        {
            var generation = await _homeService.GetById(id);    
            return Ok(generation);
        }
    }
}
