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
    public class EngineService : IEngineService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public EngineService(ApplicationDbContext dbContext,IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> Create(CreateEngineDTO dto)
        {
            var engine =_mapper.Map<Engine>(dto);
            await _dbContext.AddAsync(engine);
            await _dbContext.SaveChangesAsync();
            return engine.Id;
            
        }

        public async Task Delete(int id)
        {
            var engine = await _dbContext.Engines.FirstOrDefaultAsync(o => o.Id == id) ?? throw new NotFoundException("Engine not found");
            _dbContext.Engines.Remove(engine);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<EngineDTO>> GetAll()
        {
            var engines=await _dbContext.Engines.ToListAsync() ?? throw new NotFoundException("Suspensions not found");
            var engineDTOs =_mapper.Map<List<EngineDTO>>(engines);
            return engineDTOs;
        }

        public async Task<EngineDTO> GetById(int id)
        {
            var engine = await _dbContext.Engines.FirstOrDefaultAsync(o=>o.Id==id) ?? throw new NotFoundException("Engine not found");
            var engineDTO =_mapper.Map<EngineDTO>(engine);
            return engineDTO;
        }

        public async Task Update(int id,UpdateEngineDTO dto)
        {
            var engine=await _dbContext.Engines.FirstOrDefaultAsync(o=>o.Id==id);
            if (engine==null)
                throw new NotFoundException("Engine not found");

            engine.Version = dto.Version;
            engine.Capacity = dto.Capacity;
            engine.HorsePower = dto.HorsePower;
            engine.Torque = dto.Torque;
            engine.Type = dto.Type;
            engine.FuelConsumptionCity = dto.FuelConsumptionCity;
            engine.FuelConsumptionSuburban = dto.FuelConsumptionSuburban;
            await _dbContext.SaveChangesAsync();
        }
    }
}
