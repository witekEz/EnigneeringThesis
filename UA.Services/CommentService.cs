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
        public async Task<int> Create(CreateCommentDTO dto, int generationId, int authorId)
        {
            var generation=await _dbContext.Generations.FirstOrDefaultAsync(i=>i.Id == generationId) ?? throw new NotFoundException("Generation not found");
            var comment = _mapper.Map<Comment>(dto);
            comment.AuthorId = authorId;
            comment.CreatedOn = DateTime.Now;
            comment.GenerationId = generationId;
            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
            return comment.Id;
        }

        public async Task Delete(int generationId, int id, ClaimsPrincipal author)
        {
            var generation = await _dbContext.Generations.FirstOrDefaultAsync(i => i.Id == generationId) ?? throw new NotFoundException("Generation not found");
            var comment = await _dbContext.Comments.FirstOrDefaultAsync(i => i.Id == id) ?? throw new NotFoundException("Comment not found");
            var authorizationResult = _authorizationService.AuthorizeAsync(author, comment, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("You cant do that!");
            }
            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<CommentDTO>> GetAllComments(int generationId)
        {
            var generation =await _dbContext.Generations.FirstOrDefaultAsync(i => i.Id == generationId) ?? throw new NotFoundException("Generation not found");
            var comments =await _dbContext.Comments
                //.Include(i => i.Author)
                //.Include(c=>c.Replies)
                .Where(i=>i.GenerationId==generationId).ToListAsync () ?? throw new NotFoundException("Comments not found");
            var commentDTOs =_mapper.Map<List<CommentDTO>>(comments);
            return commentDTOs;
        }

        public async Task Update(UpdateCommentDTO dto, int generationId, int id, ClaimsPrincipal author)
        {
            var generation = await _dbContext.Generations.FirstOrDefaultAsync(i => i.Id == generationId) ?? throw new NotFoundException("Generation not found");
            var comment =await _dbContext.Comments.FirstOrDefaultAsync(i => i.Id == id) ?? throw new NotFoundException("Comment not found");
            var authorizationResult = _authorizationService.AuthorizeAsync(author, comment, new ResourceOperationRequirement(ResourceOperation.Update)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("You cant do that!");
            }
            comment.Content = dto.Content;
            comment.CreatedOn = DateTime.Now;
            comment.IsModified = true;
            await _dbContext.SaveChangesAsync();
        }

       
    }
}
