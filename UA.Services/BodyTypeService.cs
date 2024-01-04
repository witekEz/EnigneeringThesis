using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.DAL.EF;
using UA.Model.DTOs;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;
using UA.Model.Entities;
using UA.Services.Interfaces;
using UA.Services.Middleware.Exceptions;

namespace UA.Services
{
    public class BodyTypeService : IBodyTypeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public BodyTypeService(ApplicationDbContext dbContext, IMapper mapper) {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(int generationId, CreateBodyTypeDTO dto)
        {
            var generation=_dbContext
                .Generations
                .FirstOrDefault(o=>o.Id == generationId);
            if (generation == null)
                throw new NotFoundException("Generation not found");

            var bodyType = _mapper.Map<BodyType>(dto);
            bodyType.GenerationId = generationId;
            _dbContext.BodyTypes.Add(bodyType);
            _dbContext.SaveChanges();
            return bodyType.Id;
        }

        public void Delete(int generationId, int id)
        {
            var generation = _dbContext
                .Generations
                .FirstOrDefault(o=>o.Id==generationId);
            if (generation == null)
                throw new NotFoundException("Generation not found");
            var bodyType=_dbContext
                .BodyTypes
                .FirstOrDefault(o=>o.Id==id);
            if (bodyType == null || bodyType.GenerationId!=generationId)
                throw new NotFoundException("Body type not found");
            _dbContext.BodyTypes.Remove(bodyType);
            _dbContext.SaveChanges();
        }

        public List<BodyTypeDTO> GetAll(int generationId)
        {
            var generation = _dbContext
                .Generations
                .Include (x => x.BodyTypes)
                .FirstOrDefault(g=>g.Id == generationId);
            if (generation == null)
            {
                throw new NotFoundException("Generation not found");
            }
            var bodyTypeDTOs = _mapper.Map<List<BodyTypeDTO>>(generation.BodyTypes);
            return bodyTypeDTOs;
        }

        public BodyTypeDTO GetById(int generationId, int id)
        {
            var generation = _dbContext
                .Generations
                .Include(o => o.BodyTypes)
                .FirstOrDefault(o => o.Id == generationId);
            if (generation == null)
                throw new NotFoundException("Generation not found");

            var bodyType=_dbContext
                .BodyTypes
                .FirstOrDefault(o=>o.Id == id);
            if (bodyType == null||bodyType.GenerationId!=generationId)
                throw new NotFoundException("Body type not found");

            var bodyTypeDTO = _mapper.Map<BodyTypeDTO>(bodyType);
            return bodyTypeDTO;
        }

        public void Update(int id,UpdateBodyTypeDTO bodyTypeDTO)
        {
            var bodyType=_dbContext.BodyTypes.FirstOrDefault(o=>o.Id==id);
            if (bodyType == null)
                throw new NotFoundException("Body type not found");

            bodyType.Name = bodyTypeDTO.Name;
            bodyType.Segment = bodyTypeDTO.Segment;
            bodyType.NumberOfDoors= bodyTypeDTO.NumberOfDoors;
            bodyType.NumberOfSeats= bodyTypeDTO.NumberOfSeats;
            bodyType.TrunkCapacity= bodyTypeDTO.TrunkCapacity;
            _dbContext.SaveChanges();
        }
    }
}
