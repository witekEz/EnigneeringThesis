using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
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

        public int Create(CreateRateGenerationDTO dto, int generationId, int userId)
        {
            var generation=_dbContext.Generations.FirstOrDefault(i=>i.Id==generationId);
            if (generation == null)
            {
                throw new NotFoundException("Generation not found");
            }

            var ratesGeneration = _dbContext.RateGenerations.ToList();
            var avgRateGeneration=_dbContext.AvgRateGenerations.FirstOrDefault(i=>i.GenerationId==generationId);

            if (avgRateGeneration == null)
            {
                var createAvgRateGeneration=new CreateAvgRateGenerationDTO() 
                { 
                    Value=0.0,
                    NumberOfRates=0,
                    GenerationId=generationId,
                };
                var newAvgRateGeneration=_mapper.Map<AvgRateGeneration>(createAvgRateGeneration);
                _dbContext.AvgRateGenerations.Add(newAvgRateGeneration);
                _dbContext.SaveChanges();

                avgRateGeneration = _dbContext.AvgRateGenerations.FirstOrDefault(i => i.GenerationId == generationId);
            }

            if (ratesGeneration != null && avgRateGeneration != null)
            {
                double sum=0;

                foreach (var rate in ratesGeneration)
                {
                    sum += rate.Value;
                }
                sum += dto.Value;
                var newAvgRate = sum / (ratesGeneration.Where(i => i.GenerationId == generationId).Count()+1);
                avgRateGeneration.AverageRate= newAvgRate;
                avgRateGeneration.NumberOfRates = ratesGeneration.Count() + 1;
            }
            else
            {
                throw new NotFoundException("Rates not found or average rate does not exist");
            }
            
            var rateGeneration = _mapper.Map<RateGeneration>(dto);
            rateGeneration.UserID = userId;
            _dbContext.RateGenerations.Add(rateGeneration);
            _dbContext.SaveChanges();
            return rateGeneration.Id;
        }
        public void Delete(int id, int generationId, ClaimsPrincipal user)
        {
            var generation = _dbContext.Generations.FirstOrDefault(i => i.Id == generationId);
            if (generation == null)
            {
                throw new NotFoundException("Generation not found");
            }
            var rateGeneration=_dbContext.RateGenerations.FirstOrDefault(i=>i.Id == id);
            if (rateGeneration == null)
            {
                throw new NotFoundException("This rate does not exsist");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(user, rateGeneration, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }
            _dbContext.RateGenerations.Remove(rateGeneration);
            _dbContext.SaveChanges();
        }
        public AvgRateGenerationDTO Get(int generationId)
        {
            var generation=_dbContext.Generations.FirstOrDefault(i=>i.Id==generationId);
            if (generation == null)
            {
                throw new NotFoundException("Generation not found");
            }
            var avgRateGeneration = _dbContext.AvgRateGenerations.FirstOrDefault(i=>i.GenerationId==generationId);
            if (avgRateGeneration == null)
            {
                throw new NotFoundException($"Average rate for generation with ID:{generation.Id} not found");
            }
            var avgRateGenerationDTO=_mapper.Map<AvgRateGenerationDTO>(avgRateGeneration);
            return avgRateGenerationDTO;
        }
        public void Update(UpdateRateGenerationDTO dto, int generationId, int id, ClaimsPrincipal user)
        {
            
            var generation = _dbContext.Generations.FirstOrDefault(i => i.Id == generationId);
            if (generation == null)
            {
                throw new NotFoundException("Generation not found");
            }
            var rateGeneration = _dbContext.RateGenerations.FirstOrDefault(i=>i.Id==id);
            if(rateGeneration == null)
            {
                throw new NotFoundException($"Rate for generation with ID: {generation.Id} not found");
            }
            var authorizationResult=_authorizationService.AuthorizeAsync(user, rateGeneration, new ResourceOperationRequirement(ResourceOperation.Update)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }

            rateGeneration.Value = dto.Value;
            _dbContext.SaveChanges();

        }
    }
}
