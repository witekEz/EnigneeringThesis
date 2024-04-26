using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;
using UA.Services;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("api/comment/{commentId}/reply")]
    [ApiController]
    public class CommentReplyController : Controller
    {
        private readonly ICommentReplyService _commentReplyService;
        public CommentReplyController(ICommentReplyService commentReplyService) 
        {
            _commentReplyService = commentReplyService;
        }
        [HttpPost]
        [Authorize(Roles = "Admin,SuperUser,User")]
        public ActionResult Create([FromBody] CreateCommentReplyDTO dto, [FromRoute] int commentId)
        {
            var authorId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var replyId = _commentReplyService.Create(dto, commentId, authorId);
            return Created($"api/comment/{commentId}/reply/{commentId}", null);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Delete([FromRoute] int id, [FromRoute] int commentId)
        {
            _commentReplyService.Delete(commentId, id, User);
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperUser")]
        public ActionResult Update([FromBody] UpdateCommentReplyDTO dto, [FromRoute] int id, [FromRoute] int commentId)
        {
            _commentReplyService.Update(dto, commentId, id, User);
            return NoContent();
        }
    }
}
