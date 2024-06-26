﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Read;
using UA.Model.DTOs.Update;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{

    [Route("api/generation/{generationId}/comment")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<CommentDTO>>> Get([FromRoute] int generationId)
        {
            var comments = await _commentService.GetAllComments(generationId);
            return Ok(comments);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser,User")]
        public async Task<IActionResult> Create([FromBody]CreateCommentDTO dto, [FromRoute] int generationId)
        {
            var authorId= int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var commentId = await _commentService.Create(dto, generationId, authorId);
            return Created($"api/generation/{generationId}/comment/{commentId}",null);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Delete([FromRoute]int id,[FromRoute]int generationId) 
        {
            await _commentService.Delete(generationId, id, User);
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> Update([FromBody]UpdateCommentDTO dto,[FromRoute] int id, [FromRoute]int generationId)
        {
            await _commentService.Update(dto, generationId, id, User);
            return NoContent();
        }
        
    }
}
