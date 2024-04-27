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

        public async Task<int> Create(int generationId, CreateBodyDTO dto)
        {
            var generation=await _dbContext
                .Generations
                .FirstOrDefaultAsync(o=>o.Id == generationId) ?? throw new NotFoundException("Generation not found");
            var body = _mapper.Map<Body>(dto);
            body.GenerationId = generationId;
            if (dto.BodyTypeId != 0)
            {
                var bodyTypeEntity = await _dbContext.BodyTypes.FirstOrDefaultAsync(bt => bt.Id == dto.BodyTypeId);
                body.BodyType = bodyTypeEntity;
            }
            await _dbContext.Bodies.AddAsync(body);
            await _dbContext.SaveChangesAsync();
            return body.Id;
        }

        public async Task Delete(int generationId, int id)
        {
            var generation = await _dbContext
                .Generations
                .FirstOrDefaultAsync(o=>o.Id==generationId) ?? throw new NotFoundException("Generation not found");
            var body =await _dbContext
                .Bodies
                .FirstOrDefaultAsync(o=>o.Id==id);
            if (body == null || body.GenerationId!=generationId)
                throw new NotFoundException("Body not found");
            _dbContext.Bodies.Remove(body);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<BodyDTO>> GetAll(int generationId)
        {
            var generation = await _dbContext
                .Generations            
                .FirstOrDefaultAsync(g=>g.Id == generationId) ?? throw new NotFoundException("Generation not found");
            var bodyDTOs = _mapper.Map<List<BodyDTO>>(generation.Bodies);
            return bodyDTOs;
        }

        public async Task<BodyDTO> GetById(int generationId, int id)
        {
            var generation = await _dbContext
                .Generations
                .FirstOrDefaultAsync(o => o.Id == generationId);
            if (generation == null)
                throw new NotFoundException("Generation not found");

            var body=await _dbContext
                .Bodies
                .FirstOrDefaultAsync(o=>o.Id == id);

            if (body == null||body.GenerationId!=generationId)
                throw new NotFoundException("Bodies not found");

            var bodyDTO = _mapper.Map<BodyDTO>(body);
            return bodyDTO;
        }

        public async Task Update(int id,UpdateBodyDTO bodyDTO)
        {
            var body=await _dbContext.Bodies.FirstOrDefaultAsync(o => o.Id == id) ?? throw new NotFoundException("Body type not found");
            body.Segment = bodyDTO.Segment;
            body.NumberOfDoors= bodyDTO.NumberOfDoors;
            body.NumberOfSeats= bodyDTO.NumberOfSeats;
            body.TrunkCapacity= bodyDTO.TrunkCapacity;
            await _dbContext.SaveChangesAsync();
        }
    }
}
