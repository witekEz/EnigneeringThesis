using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UA.DAL.EF;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Read;
using UA.Model.DTOs.Update;
using UA.Model.Entities;
using UA.Model.Entities.Authentication;
using UA.Model.Entities.Rate;
using UA.Services.Authorization;
using UA.Services.Interfaces;
using UA.Services.Middleware.Exceptions;

namespace UA.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;
        public CommentService(ApplicationDbContext dbContext, IMapper mapper, IAuthorizationService authorizationService) 
        {
            _authorizationService = authorizationService;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int Create(CreateCommentDTO dto, int generationId, int authorId)
        {
            var generation=_dbContext.Generations.FirstOrDefault(i=>i.Id == generationId);
            if (generation == null)
            {
                throw new NotFoundException("Generation not found"); 
            }
            var comment = _mapper.Map<Comment>(dto);
            comment.AuthorId = authorId;
            comment.CreatedOn = DateTime.Now;
            comment.GenerationId = generationId;
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
            return comment.Id;
        }

        public void Delete(int generationId, int id, ClaimsPrincipal author)
        {
            var generation = _dbContext.Generations.FirstOrDefault(i => i.Id == generationId);
            if (generation == null)
            {
                throw new NotFoundException("Generation not found");
            }
            var comment = _dbContext.Comments.FirstOrDefault(i => i.Id == id);
            if (comment == null)
            {
                throw new NotFoundException("Comment not found");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(author, comment, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }
            _dbContext.Comments.Remove(comment);
            _dbContext.SaveChanges();
        }

        public List<CommentDTO> GetAllComments(int generationId)
        {
            var generation = _dbContext.Generations.FirstOrDefault(i => i.Id == generationId);
            if (generation == null)
            {
                throw new NotFoundException("Generation not found");
            }
            var comments=_dbContext.Comments
                .Include(i => i.Author)
                .Include(c=>c.Replies)
                .Where(i=>i.GenerationId==generationId).ToList();
            if (comments == null)
            {
                throw new NotFoundException("Comments not found");
            }
            var commentDTOs=_mapper.Map<List<CommentDTO>>(comments);
            return commentDTOs;
        }

        public void Update(UpdateCommentDTO dto, int generationId, int id, ClaimsPrincipal author)
        {
            var generation = _dbContext.Generations.FirstOrDefault(i => i.Id == generationId);
            if (generation == null)
            {
                throw new NotFoundException("Generation not found");
            }
            var comment=_dbContext.Comments.FirstOrDefault(i => i.Id == id);
            if (comment == null)
            {
                throw new NotFoundException("Comment not found");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(author, comment, new ResourceOperationRequirement(ResourceOperation.Update)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }
            comment.Content = dto.Content;
            comment.CreatedOn = DateTime.Now;
            comment.IsModified = true;
            _dbContext.SaveChanges();
        }

       
    }
}
