using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
using UA.Model.Entities.Rate;
using UA.Model.Entities;
using UA.Services.Interfaces;
using UA.Services.Middleware.Exceptions;
using UA.Services.Authorization;

namespace UA.Services
{
    public class RateEngineService:IRateEngineService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;
        public RateEngineService(ApplicationDbContext dbContext, IMapper mapper, IAuthorizationService authorizationService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }

        public int Create(CreateRateEngineDTO dto, int engineId, int userId)
        {
            var engine = _dbContext.Engines.FirstOrDefault(i => i.Id == engineId);
            if (engine == null)
            {
                throw new NotFoundException("Engine not found");
            }

            var ratesEngine = _dbContext.RateEngines.Where(e => e.EngineId == engineId).ToList();
            var avgRateEngine = _dbContext.AvgRateEngines.FirstOrDefault(i => i.EngineId == engineId);

            if (avgRateEngine == null)
            {
                var createAvgRateEngine = new CreateAvgRateEngineDTO()
                {
                    Value = 0.0,
                    NumberOfRates = 0,
                    EngineId = engineId,
                };
                var newAvgRateEngine = _mapper.Map<AvgRateEngine>(createAvgRateEngine);
                _dbContext.AvgRateEngines.Add(newAvgRateEngine);
                _dbContext.SaveChanges();

                avgRateEngine = _dbContext.AvgRateEngines.FirstOrDefault(i => i.EngineId == engineId);
            }

            if (ratesEngine != null && avgRateEngine != null)
            {
                double sum = 0;

                foreach (var rate in ratesEngine)
                {
                    sum += rate.Value;
                }
                sum += dto.Value;
                var newAvgRate = sum / (ratesEngine.Count() + 1);
                newAvgRate = (double)System.Math.Round(newAvgRate, 2);
                avgRateEngine.AverageRate = newAvgRate;
                avgRateEngine.NumberOfRates = ratesEngine.Count() + 1;
            }
            else
            {
                throw new NotFoundException("Rates not found or average rate does not exist");
            }

            var rateEngine = _mapper.Map<RateEngine>(dto);
            rateEngine.UserID = userId;
            _dbContext.RateEngines.Add(rateEngine);
            _dbContext.SaveChanges();
            return rateEngine.Id;
        }

        public void Delete(int engineId, int id, ClaimsPrincipal user)
        {
            var engine = _dbContext.Engines.FirstOrDefault(i => i.Id == engineId);
            if (engine == null)
            {
                throw new NotFoundException("Engine not found");
            }
            var rateEngine = _dbContext.RateEngines.FirstOrDefault(i => i.Id == id);
            if (rateEngine == null)
            {
                throw new NotFoundException("This rate does not exsist");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(user, rateEngine, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("You cant do that!");
            }
            _dbContext.RateEngines.Remove(rateEngine);
            _dbContext.SaveChanges();
        }

        public AvgRateEngineDTO Get(int engineId)
        {
            var engine = _dbContext.Engines.FirstOrDefault(i => i.Id == engineId);
            if (engine == null)
            {
                throw new NotFoundException("Generation not found");
            }
            var avgRateEngine = _dbContext.AvgRateEngines.FirstOrDefault(i => i.EngineId == engineId);
            if (avgRateEngine == null)
            {
                throw new NotFoundException($"Average rate for engine with ID:{engine.Id} not found");
            }
            var avgRateEngineDTO = _mapper.Map<AvgRateEngineDTO>(avgRateEngine);
            return avgRateEngineDTO;
        }

        public void Update(UpdateRateEngineDTO dto, int engineId, int id, ClaimsPrincipal user)
        {
            var engine = _dbContext.Engines.FirstOrDefault(i => i.Id == engineId);
            if (engine == null)
            {
                throw new NotFoundException("Engine not found");
            }
            var rateEngine = _dbContext.RateEngines.FirstOrDefault(i => i.Id == id);
            if (rateEngine == null)
            {
                throw new NotFoundException($"Rate for engine with ID: {engine.Id} not found");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(user, rateEngine, new ResourceOperationRequirement(ResourceOperation.Update)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("You cant do that!");
            }

            rateEngine.Value = dto.Value;
            _dbContext.SaveChanges();
        }
    }
}
