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
    public class OptionalEquipmentService : IOptionalEquipmentService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public OptionalEquipmentService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> Create(int generationId, CreateOptionalEquipmentDTO dto)
        {
            var generation = _dbContext
                .Generations
                .FirstOrDefault(o => o.Id == generationId) ?? throw new NotFoundException("Generation not found");
            var optionalEquipment = _mapper.Map<OptionalEquipment>(dto);
            optionalEquipment.GenerationId = generationId;
            await _dbContext.OptionalEquipments.AddAsync(optionalEquipment);
            await _dbContext.SaveChangesAsync();
            return optionalEquipment.Id;
        }

        public async Task Delete(int generationId)
        {
            var optionalEquipment = await _dbContext
                .OptionalEquipments
                .FirstOrDefaultAsync(o => o.Id == generationId);
            if (optionalEquipment == null || optionalEquipment.GenerationId != generationId)
                throw new NotFoundException("Optional equipment not found");

            _dbContext.OptionalEquipments.Remove(optionalEquipment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<OptionalEquipmentDTO> GetById(int generationId)
        {
            var optionalEquipment = await _dbContext
                .OptionalEquipments
                .FirstOrDefaultAsync(o => o.Id == generationId) ?? throw new NotFoundException("Optional equipment not found");
            var optionalEquipmentDTO = _mapper.Map<OptionalEquipmentDTO>(optionalEquipment);
            return optionalEquipmentDTO;
        }

        public async Task Update(UpdateOptionalEquipmentDTO dto, int generationId)
        {
            var optionalEquipment = await _dbContext
                .OptionalEquipments
                .FirstOrDefaultAsync(o => o.Id == generationId) ?? throw new NotFoundException("Optional equipment not found");
            optionalEquipment.RearAxleSteering = dto.RearAxleSteering;
            optionalEquipment.StandardTailPipes = dto.StandardTailPipes;
            optionalEquipment.Rooftop= dto.Rooftop;
            optionalEquipment.ABS= dto.ABS;
            optionalEquipment.ESP= dto.ESP;
            optionalEquipment.ASR= dto.ASR;
            await _dbContext.SaveChangesAsync();
        }
    }
}
