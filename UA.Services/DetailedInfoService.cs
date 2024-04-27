using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.DAL.EF;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Read;
using UA.Model.DTOs.Update;
using UA.Model.Entities;
using UA.Services.Interfaces;
using UA.Services.Middleware.Exceptions;

namespace UA.Services
{
    public class DetailedInfoService:IDetailedInfoService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public DetailedInfoService(ApplicationDbContext dbContext,IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> Create(int generationId, CreateDetailedInfoDTO dto)
        {
            var generation=await _dbContext
                .Generations
                .FirstOrDefaultAsync(o=>o.Id == generationId) ?? throw new NotFoundException("Generation not found");
            var detailedInfo = _mapper.Map<DetailedInfo>(dto);
            detailedInfo.GenerationId= generationId;

            if (dto.BodyColours!=null)
            {
                var bodyColoursEntity = await _dbContext.BodyColours.Where(data => dto.BodyColours.Contains(data.Id)).ToListAsync();
                detailedInfo.BodyColours = bodyColoursEntity;
            }
            if (dto.Brakes != null)
            {
                var brakesEntity = await _dbContext.Brakes.Where(data => dto.Brakes.Contains(data.Id)).ToListAsync();
                detailedInfo.Brakes = brakesEntity;
            }
            if (dto.Suspensions != null)
            {
                var suspensionsEntity = _dbContext.Suspensions.Where(data => dto.Suspensions.Contains(data.Id)).ToList();
                detailedInfo.Suspensions = suspensionsEntity;
            }

            await _dbContext.DeatiledInfos.AddAsync(detailedInfo);
            await _dbContext.SaveChangesAsync();
            return detailedInfo.Id;
        }

        public async Task Delete(int generationId)
        {
            var detailedInfo=await _dbContext
                .DeatiledInfos
                .FirstOrDefaultAsync(o=>o.Id==generationId);
            if (detailedInfo == null || detailedInfo.GenerationId != generationId)
                throw new NotFoundException("DetailedInfo not found");

            _dbContext.DeatiledInfos.Remove(detailedInfo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<DetailedInfoDTO> GetById(int generationId)
        {
            var detailedInfo = _dbContext
                .DeatiledInfos
                //.Include(o => o.Suspensions)
                //.Include(o => o.Brakes)
                //.Include(o => o.BodyColours)
                .FirstOrDefaultAsync(o => o.Id == generationId) ?? throw new NotFoundException("DetailedInfo not found");
            var detailedDTO =_mapper.Map<DetailedInfoDTO>(detailedInfo);
            return detailedDTO;
                
        }

        public async Task Update(UpdateDetailedInfoDTO dto, int generationId)
        {
            var detailedInfo=await _dbContext
                .DeatiledInfos
                .FirstOrDefaultAsync(o => o.Id == generationId);
            if (detailedInfo == null)
                throw new NotFoundException("DetailedInfo not found");

            detailedInfo.ProductionStartDate = dto.ProductionStartDate;
            detailedInfo.ProductionEndDate = dto.ProductionEndDate;
            await _dbContext.SaveChangesAsync();
        }
    }
}
