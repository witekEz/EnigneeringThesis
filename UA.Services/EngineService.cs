using AutoMapper;
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
    public class EngineService : IEngineService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public EngineService(ApplicationDbContext dbContext,IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int Create(CreateEngineDTO dto)
        {
            var engine =_mapper.Map<Engine>(dto);
            _dbContext.Add(engine);
            _dbContext.SaveChanges();
            return engine.Id;
            
        }

        public void Delete(int id)
        {
            var engine = _dbContext.Engines.FirstOrDefault(o => o.Id == id);
            if (engine == null)
                throw new NotFoundException("Engine not found");
            _dbContext.Remove(engine);
            _dbContext.SaveChanges();
        }

        public List<EngineDTO> GetAll()
        {
            var engines=_dbContext.Engines.ToList();
            if (engines == null)
                throw new NotFoundException("Suspensions not found");
            var engineDTOs=_mapper.Map<List<EngineDTO>>(engines);
            return engineDTOs;
        }

        public EngineDTO GetById(int id)
        {
            var engine = _dbContext.Engines.FirstOrDefault(o=>o.Id==id);
            if (engine==null)
                throw new NotFoundException("Engine not found");
            var engineDTO=_mapper.Map<EngineDTO>(engine);
            return engineDTO;
        }

        public void Update(int id,UpdateEngineDTO dto)
        {
            var engine=_dbContext.Engines.FirstOrDefault(o=>o.Id==id);
            if (engine==null)
                throw new NotFoundException("Engine not found");

            engine.Version = dto.Version;
            engine.Capacity = dto.Capacity;
            engine.HorsePower = dto.HorsePower;
            engine.Torque = dto.Torque;
            engine.Type = dto.Type;
            engine.FuelConsumptionCity = dto.FuelConsumptionCity;
            engine.FuelConsumptionSuburban = dto.FuelConsumptionSuburban;
            engine.Rate = dto.Rate;
            _dbContext.SaveChanges();
        }
    }
}
