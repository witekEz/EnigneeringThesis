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
using UA.Services.Interfaces;
using UA.Services.Middleware.Exceptions;

namespace UA.Services
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public HomeService(ApplicationDbContext dbContext, IMapper mapper) {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<GenerationDTO> GetAll()
        {
            var generations = _dbContext
                .Generations
                .ToList();
            if (generations is null)
            {
                throw new NotFoundException("Generation not found");
            }
            var generationDTOs = _mapper.Map<List<GenerationDTO>>(generations);
            return generationDTOs;

        }

        public GenerationDTO GetById(int id)
        {
            var generation=_dbContext
                .Generations
                .Include(b => b.BodyTypes)
                .Include(b => b.Drivetrains)
                .Include(b => b.Engines)
                .Include(b => b.Gearboxes)
                .Include(b => b.DetailedInfo)
                .Include(b => b.DetailedInfo.Suspensions)
                .Include(b => b.DetailedInfo.BodyColours)
                .Include(b => b.DetailedInfo.Brakes)
                .Include(b => b.OptionalEquipment)
                .Include(b => b.Model)
                .Include(b => b.Model.Brand)
                .FirstOrDefault(g=> g.Id == id);
            if (generation is null)
            {
                throw new NotFoundException("Generation not found");
            }
            var generationDTO=_mapper.Map<GenerationDTO>(generation);
            return generationDTO;
        }
    }
}
