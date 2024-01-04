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
    public class OptionalEquipmentService : IOptionalEquipmentService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public OptionalEquipmentService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int Create(int generationId, CreateOptionalEquipmentDTO dto)
        {
            var generation = _dbContext
                .Generations
                .FirstOrDefault(o => o.Id == generationId);
            if (generation == null)
                throw new NotFoundException("Generation not found");

            var optionalEquipment = _mapper.Map<OptionalEquipment>(dto);
            optionalEquipment.GenerationId = generationId;
            _dbContext.OptionalEquipments.Add(optionalEquipment);
            _dbContext.SaveChanges();
            return optionalEquipment.Id;
        }

        public void Delete(int generationId)
        {
            var optionalEquipment = _dbContext
                .OptionalEquipments
                .FirstOrDefault(o => o.Id == generationId);
            if (optionalEquipment == null || optionalEquipment.GenerationId != generationId)
                throw new NotFoundException("Optional equipment not found");

            _dbContext.OptionalEquipments.Remove(optionalEquipment);
            _dbContext.SaveChanges();
        }

        public OptionalEquipmentDTO GetById(int generationId)
        {
            var optionalEquipment = _dbContext
                .OptionalEquipments
                .FirstOrDefault(o => o.Id == generationId);
            if (optionalEquipment == null)
                throw new NotFoundException("Optional equipment not found");

            var optionalEquipmentDTO = _mapper.Map<OptionalEquipmentDTO>(optionalEquipment);
            return optionalEquipmentDTO;
        }

        public void Update(UpdateOptionalEquipmentDTO dto, int generationId)
        {
            var optionalEquipment = _dbContext
                .OptionalEquipments
                .FirstOrDefault(o => o.Id == generationId);
            if (optionalEquipment == null)
                throw new NotFoundException("Optional equipment not found");

            optionalEquipment.RearAxleSteering = dto.RearAxleSteering;
            optionalEquipment.StandardTailPipes = dto.StandardTailPipes;
            optionalEquipment.Rooftop= dto.Rooftop;
            optionalEquipment.ABS= dto.ABS;
            optionalEquipment.ESP= dto.ESP;
            optionalEquipment.ASR= dto.ASR;
            _dbContext.SaveChanges();
        }
    }
}
