using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.DAL.EF;
using UA.Model.DTOs;
using UA.Model.Entities;
using UA.Model.DTOs.Create;
using UA.Services.Interfaces;
using UA.Model.DTOs.Update;
using Microsoft.Extensions.Logging;

namespace UA.Services
{
    public class GenerationService:IGenerationService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<GenerationService> _logger;
        public GenerationService(ApplicationDbContext dbContext, IMapper mapper, ILogger<GenerationService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public bool Delete(int id)
        {
            _logger.LogError($"Generation with ID: {id} DELETE action invoked");
            var generation=_dbContext
                .Generations
                .FirstOrDefault(g=>g.Id==id);

            if (generation is null) return false; 

            _dbContext.Generations.Remove(generation);
            _dbContext.SaveChanges();
            return true;
        }

        public GenerationDTO GetById(int id)
        {
            _logger.LogError($"Generation with ID:{id} GET action invoked");
            var generation = _dbContext.Generations
               .Include(b => b.BodyTypes)
               .Include(b => b.Drivetrains)
               .Include(b => b.Engines)
               .Include(b => b.Gearboxes)
               .Include(b => b.DeatiledInfo)
               .Include(b => b.DeatiledInfo.Suspensions)
               .Include(b => b.DeatiledInfo.BodyColours)
               .Include(b => b.DeatiledInfo.Brakes)
               .Include(b => b.OptionalEquipment)
               .Include(b => b.Model)
               .Include(b => b.Model.Brand)
               .FirstOrDefault(p => p.Id == id);

            if (generation is null) { return null; }

            var generationDTO = _mapper.Map<GenerationDTO>(generation);
            return generationDTO;
        }
        public IEnumerable<GenerationDTO> GetAll()
        {
            _logger.LogError($"Generations GET action invoked");
            var generations = _dbContext
                .Generations
                .Include(b => b.BodyTypes)
                .Include(b => b.Drivetrains)
                .Include(b => b.Engines)
                .Include(b => b.Gearboxes)
                .Include(b => b.DeatiledInfo)
                .Include(b => b.DeatiledInfo.Suspensions)
                .Include(b => b.DeatiledInfo.BodyColours)
                .Include(b => b.DeatiledInfo.Brakes)
                .Include(b => b.OptionalEquipment)
                .Include(b => b.Model)
                .Include(b => b.Model.Brand)
                .ToList();

            var generationsDTOs = _mapper.Map<List<GenerationDTO>>(generations);
            return generationsDTOs;
        }
        public int Create(CreateGenerationDTO dto)
        {
            _logger.LogError($"Generation object: {dto} POST action invoked");
            var generation = _mapper.Map<Generation>(dto);
            _dbContext.Generations.Add(generation);
            _dbContext.SaveChanges();
            return generation.Id;
        }

        public bool Update(UpdateGenerationDTO dto, int id)
        {
            _logger.LogError($"Generation with ID: {id} UPDATE action invoked");
            var generation = _dbContext.Generations.FirstOrDefault(g => g.Id == id);
            if (generation is null) return false;
            generation= _mapper.Map(dto,generation);
            //generation.Name = dto.Name;
            //_dbContext.Entry(generation).CurrentValues.SetValues(dto);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
