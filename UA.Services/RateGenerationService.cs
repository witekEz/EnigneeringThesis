using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UA.DAL.EF;
using UA.Model.DTOs.Create.Rate;
using UA.Model.DTOs.Read.Rate;
using UA.Model.DTOs.Update.Rate;
using UA.Model.Entities.Authentication;
using UA.Model.Entities.Rate;
using UA.Services.Authorization;
using UA.Services.Interfaces;
using UA.Services.Middleware.Exceptions;

namespace UA.Services
{
    public class RateGenerationService:IRateGenerationService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;
        public RateGenerationService(ApplicationDbContext dbContext, IMapper mapper, IAuthorizationService authorizationService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }

        public async Task<int> Create(CreateRateGenerationDTO dto, int generationId, int userId)
        {
            var generation=await _dbContext.Generations.FirstOrDefaultAsync(i=>i.Id==generationId) ?? throw new NotFoundException("Generation not found");
            var ratesGeneration = await _dbContext.RateGenerations.Where(g=>g.GenerationId==generationId).ToListAsync();
            var avgRateGeneration=await _dbContext.AvgRateGenerations.FirstOrDefaultAsync(i=>i.GenerationId==generationId);

            if (avgRateGeneration == null)
            {
                var createAvgRateGeneration=new CreateAvgRateGenerationDTO() 
                { 
                    Value=0.0,
                    NumberOfRates=0,
                    GenerationId=generationId,
                };
                var newAvgRateGeneration=_mapper.Map<AvgRateGeneration>(createAvgRateGeneration);
                await _dbContext.AvgRateGenerations.AddAsync(newAvgRateGeneration);
                await _dbContext.SaveChangesAsync();

                avgRateGeneration = await _dbContext.AvgRateGenerations.FirstOrDefaultAsync(i => i.GenerationId == generationId);
            }

            if (ratesGeneration != null && avgRateGeneration != null)
            {
                double sum=0;

                foreach (var rate in ratesGeneration)
                {
                    sum += rate.Value;
                }
                sum += dto.Value;
                var newAvgRate = sum / (ratesGeneration.Count()+1);
                newAvgRate = (double)System.Math.Round(newAvgRate, 2);
                avgRateGeneration.AverageRate= newAvgRate;
                avgRateGeneration.NumberOfRates = ratesGeneration.Count() + 1;
            }
            else
            {
                throw new NotFoundException("Rates not found or average rate does not exist");
            }
            
            var rateGeneration = _mapper.Map<RateGeneration>(dto);
            rateGeneration.UserID = userId;
            rateGeneration.GenerationId = generationId;
            await _dbContext.RateGenerations.AddAsync(rateGeneration);
            await _dbContext.SaveChangesAsync();
            return rateGeneration.Id;
        }
        public async Task Delete(int id, int generationId, ClaimsPrincipal user)
        {
            var generation = await _dbContext.Generations.FirstOrDefaultAsync(i => i.Id == generationId) ?? throw new NotFoundException("Generation not found");
            var rateGeneration =await _dbContext.RateGenerations.FirstOrDefaultAsync(i=>i.Id == id) ?? throw new NotFoundException("This rate does not exsist");
            var authorizationResult = _authorizationService.AuthorizeAsync(user, rateGeneration, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("You cant do that!");
            }
            _dbContext.RateGenerations.Remove(rateGeneration);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<AvgRateGenerationDTO> Get(int generationId)
        {
            var generation=await _dbContext.Generations.FirstOrDefaultAsync(i => i.Id == generationId) ?? throw new NotFoundException("Generation not found");
            var avgRateGeneration = await _dbContext.AvgRateGenerations.FirstOrDefaultAsync(i=>i.GenerationId==generationId) ?? throw new NotFoundException($"Average rate for generation with ID:{generation.Id} not found");
            var avgRateGenerationDTO =_mapper.Map<AvgRateGenerationDTO>(avgRateGeneration);
            return avgRateGenerationDTO;
        }
        public async Task Update(UpdateRateGenerationDTO dto, int generationId, int id, ClaimsPrincipal user)
        {
            
            var generation = await _dbContext.Generations.FirstOrDefaultAsync(i => i.Id == generationId) ?? throw new NotFoundException("Generation not found");
            var rateGeneration =await  _dbContext.RateGenerations.FirstOrDefaultAsync(i=>i.Id==id) ?? throw new NotFoundException($"Rate for generation with ID: {generation.Id} not found");
            var authorizationResult =_authorizationService.AuthorizeAsync(user, rateGeneration, new ResourceOperationRequirement(ResourceOperation.Update)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("You cant do that!");
            }

            rateGeneration.Value = dto.Value;
            await _dbContext.SaveChangesAsync();

        }
    }
}
