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
    public class BodyService : IBodyService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public BodyService(ApplicationDbContext dbContext, IMapper mapper) {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(int generationId, CreateBodyDTO dto)
        {
            var generation=_dbContext
                .Generations
                .FirstOrDefault(o=>o.Id == generationId);
            if (generation == null)
                throw new NotFoundException("Generation not found");

            var body = _mapper.Map<Body>(dto);
            body.GenerationId = generationId;
            if (dto.BodyTypeId != 0)
            {
                var bodyTypeEntity = _dbContext.BodyTypes.FirstOrDefault(bt => bt.Id == dto.BodyTypeId);
                body.BodyType = bodyTypeEntity;
            }
            _dbContext.Bodies.Add(body);
            _dbContext.SaveChanges();
            return body.Id;
        }

        public void Delete(int generationId, int id)
        {
            var generation = _dbContext
                .Generations
                .FirstOrDefault(o=>o.Id==generationId);
            if (generation == null)
                throw new NotFoundException("Generation not found");
            var body=_dbContext
                .Bodies
                .FirstOrDefault(o=>o.Id==id);
            if (body == null || body.GenerationId!=generationId)
                throw new NotFoundException("Body not found");
            _dbContext.Bodies.Remove(body);
            _dbContext.SaveChanges();
        }

        public List<BodyDTO> GetAll(int generationId)
        {
            var generation = _dbContext
                .Generations
                .Include (x => x.Bodies)
                
                .FirstOrDefault(g=>g.Id == generationId);

            if (generation == null)
            {
                throw new NotFoundException("Generation not found");
            }

            var bodyDTOs = _mapper.Map<List<BodyDTO>>(generation.Bodies);
            return bodyDTOs;
        }

        public BodyDTO GetById(int generationId, int id)
        {
            var generation = _dbContext
                .Generations
                .Include(o => o.Bodies)
                .FirstOrDefault(o => o.Id == generationId);
            if (generation == null)
                throw new NotFoundException("Generation not found");

            var body=_dbContext
                .Bodies
                .FirstOrDefault(o=>o.Id == id);

            if (body == null||body.GenerationId!=generationId)
                throw new NotFoundException("Bodies not found");

            var bodyDTO = _mapper.Map<BodyDTO>(body);
            return bodyDTO;
        }

        public void Update(int id,UpdateBodyDTO bodyDTO)
        {
            var body=_dbContext.Bodies.FirstOrDefault(o=>o.Id==id);
            if (body == null)
                throw new NotFoundException("Body type not found");

            body.Segment = bodyDTO.Segment;
            body.NumberOfDoors= bodyDTO.NumberOfDoors;
            body.NumberOfSeats= bodyDTO.NumberOfSeats;
            body.TrunkCapacity= bodyDTO.TrunkCapacity;
            _dbContext.SaveChanges();
        }
    }
}
