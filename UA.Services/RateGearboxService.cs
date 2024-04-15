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
    public class RateGearboxService:IRateGearboxService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;
        public RateGearboxService(ApplicationDbContext dbContext, IMapper mapper, IAuthorizationService authorizationService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }

        public int Create(CreateRateGearboxDTO dto, int gearboxId, int userId)
        {
            var gearbox = _dbContext.Gearboxes.FirstOrDefault(i => i.Id == gearboxId);
            if (gearbox == null)
            {
                throw new NotFoundException("Gearbox not found");
            }

            var ratesGearbox = _dbContext.RateGearboxes.Where(e => e.GearboxId == gearboxId).ToList();
            var avgRateGearbox = _dbContext.AvgRateGearboxes.FirstOrDefault(i => i.GearboxId == gearboxId);

            if (avgRateGearbox == null)
            {
                var createAvgRateGearbox = new CreateAvgRateGearboxDTO()
                {
                    Value = 0.0,
                    NumberOfRates = 0,
                    GearboxId = gearboxId,
                };
                var newAvgRateGearbox = _mapper.Map<AvgRateGearbox>(createAvgRateGearbox);
                _dbContext.AvgRateGearboxes.Add(newAvgRateGearbox);
                _dbContext.SaveChanges();

                avgRateGearbox = _dbContext.AvgRateGearboxes.FirstOrDefault(i => i.GearboxId == gearboxId);
            }

            if (ratesGearbox != null && avgRateGearbox != null)
            {
                double sum = 0;

                foreach (var rate in ratesGearbox)
                {
                    sum += rate.Value;
                }
                sum += dto.Value;
                var newAvgRate = sum / (ratesGearbox.Count() + 1);
                newAvgRate = (double)System.Math.Round(newAvgRate, 2);
                avgRateGearbox.AverageRate = newAvgRate;
                avgRateGearbox.NumberOfRates = ratesGearbox.Count() + 1;
            }
            else
            {
                throw new NotFoundException("Rates not found or average rate does not exist");
            }

            var rateGearbox = _mapper.Map<RateGearbox>(dto);
            rateGearbox.UserID = userId;
            rateGearbox.GearboxId = gearboxId;
            _dbContext.RateGearboxes.Add(rateGearbox);
            _dbContext.SaveChanges();
            return rateGearbox.Id;
        }

        public void Delete(int gearboxId, int id, ClaimsPrincipal user)
        {
            var gearbox = _dbContext.Gearboxes.FirstOrDefault(i => i.Id == gearboxId);
            if (gearbox == null)
            {
                throw new NotFoundException("Gearbox not found");
            }
            var rateGearbox = _dbContext.RateGearboxes.FirstOrDefault(i => i.Id == id);
            if (rateGearbox == null)
            {
                throw new NotFoundException("This rate does not exsist");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(user, rateGearbox, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("You cant do that!");
            }
            _dbContext.RateGearboxes.Remove(rateGearbox);
            _dbContext.SaveChanges();
        }

        public AvgRateGearboxDTO Get(int gearboxId)
        {
            var gearbox = _dbContext.Gearboxes.FirstOrDefault(i => i.Id == gearboxId);
            if (gearbox == null)
            {
                throw new NotFoundException("Gearbox not found");
            }
            var avgRateGearbox = _dbContext.AvgRateGearboxes.FirstOrDefault(i=>i.GearboxId==gearboxId);
            if (avgRateGearbox == null)
            {
                throw new NotFoundException($"Average rate for gearbox with ID:{gearbox.Id} not found");
            }
            var avgRateGearboxDTO = _mapper.Map<AvgRateGearboxDTO>(avgRateGearbox);
            return avgRateGearboxDTO;
        }

        public void Update(UpdateRateGearboxDTO dto, int gearboxId, int id, ClaimsPrincipal user)
        {
            var gearbox = _dbContext.Gearboxes.FirstOrDefault(i => i.Id == gearboxId);
            if (gearbox == null)
            {
                throw new NotFoundException("Gearbox not found");
            }
            var rateGearbox = _dbContext.RateGearboxes.FirstOrDefault(i => i.Id == id);
            if (rateGearbox == null)
            {
                throw new NotFoundException($"Rate for gearbox with ID: {gearbox.Id} not found");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(user, rateGearbox, new ResourceOperationRequirement(ResourceOperation.Update)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("You cant do that!");
            }

            rateGearbox.Value = dto.Value;
            _dbContext.SaveChanges();
        }
    }
}
