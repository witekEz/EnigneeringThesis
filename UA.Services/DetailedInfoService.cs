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

        public int Create(int generationId, CreateDetailedInfoDTO dto)
        {
            var generation=_dbContext
                .Generations
                .FirstOrDefault(o=>o.Id == generationId);
            if (generation == null)
                throw new NotFoundException("Generation not found");

            var detailedInfo = _mapper.Map<DetailedInfo>(dto);
            detailedInfo.GenerationId= generationId;
            _dbContext.DeatiledInfos.Add(detailedInfo);
            _dbContext.SaveChanges();
            return detailedInfo.Id;
        }

        public void Delete(int generationId)
        {
            var detailedInfo=_dbContext
                .DeatiledInfos
                .FirstOrDefault(o=>o.Id==generationId);
            if (detailedInfo == null || detailedInfo.GenerationId != generationId)
                throw new NotFoundException("DetailedInfo not found");

            _dbContext.DeatiledInfos.Remove(detailedInfo);
            _dbContext.SaveChanges();
        }

        public DetailedInfoDTO GetById(int generationId)
        {
            var detailedInfo = _dbContext
                .DeatiledInfos
                .Include(o => o.Suspensions)
                .Include(o => o.Brakes)
                .Include(o => o.BodyColours)
                .FirstOrDefault(o => o.Id == generationId);
            if (detailedInfo == null)
                throw new NotFoundException("DetailedInfo not found");

            var detailedDTO=_mapper.Map<DetailedInfoDTO>(detailedInfo);
            return detailedDTO;
                
        }

        public void Update(UpdateDetailedInfoDTO dto, int generationId)
        {
            var detailedInfo=_dbContext
                .DeatiledInfos
                .FirstOrDefault(o => o.Id == generationId);
            if (detailedInfo == null)
                throw new NotFoundException("DetailedInfo not found");

            detailedInfo.ProductionStartDate = dto.ProductionStartDate;
            detailedInfo.ProductionEndDate = dto.ProductionEndDate;
            _dbContext.SaveChanges();
        }
    }
}
