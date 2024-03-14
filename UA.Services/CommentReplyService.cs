using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UA.DAL.EF;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;
using UA.Model.Entities;
using UA.Services.Authorization;
using UA.Services.Interfaces;
using UA.Services.Middleware.Exceptions;

namespace UA.Services
{
    public class CommentReplyService : ICommentReplyService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;
        public CommentReplyService(ApplicationDbContext dbContext, IMapper mapper, IAuthorizationService authorizationService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }
        public int Create(CreateCommentReplyDTO dto, int commentId, int authorId)
        {
            var comment=_dbContext.Comments.FirstOrDefault(c => c.Id == commentId);
            if (comment == null)
            {
                throw new NotFoundException("Comment not found");
            }
            var reply = _mapper.Map<CommentReply>(dto);
            reply.AuthorId = authorId;
            reply.CreatedOn = DateTime.Now;
            reply.CommentId = commentId;
            _dbContext.CommentReplies.Add(reply);
            _dbContext.SaveChanges();
            return reply.Id;
        }

        public void Delete(int commentId, int id, ClaimsPrincipal author)
        {
            var comment = _dbContext.Comments.FirstOrDefault(i => i.Id == commentId);
            if (comment == null)
            {
                throw new NotFoundException("Comment not found");
            }
            var reply = _dbContext.CommentReplies.FirstOrDefault(i => i.Id == id);
            if (reply == null)
            {
                throw new NotFoundException("Reply not found");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(author, reply, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("You cant do that!");
            }
            _dbContext.CommentReplies.Remove(reply);
            _dbContext.SaveChanges();
        }

        public void Update(UpdateCommentReplyDTO dto, int commentId, int id, ClaimsPrincipal author)
        {
            var comment = _dbContext.Comments.FirstOrDefault(i => i.Id == commentId);
            if (comment == null)
            {
                throw new NotFoundException("Comment not found");
            }
            var reply = _dbContext.CommentReplies.FirstOrDefault(i => i.Id == id);
            if (reply == null)
            {
                throw new NotFoundException("Reply not found");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(author, reply, new ResourceOperationRequirement(ResourceOperation.Update)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("You cant do that!");
            }
            reply.Content = dto.Content;
            reply.CreatedOn = DateTime.Now;
            reply.IsModified = true;
            _dbContext.SaveChanges();
        }
    }
}
