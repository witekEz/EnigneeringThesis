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
    public class GearboxService : IGearboxService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GearboxService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> Create(CreateGearboxDTO dto)
        {
            var gearbox = _mapper.Map<Gearbox>(dto);
            await _dbContext.AddAsync(gearbox);
            await _dbContext.SaveChangesAsync();
            return gearbox.Id;
        }

        public async Task Delete(int id)
        {
            var gearbox = await _dbContext.Gearboxes.FirstOrDefaultAsync(o => o.Id == id) ?? throw new NotFoundException("Gearbox not found");
            _dbContext.Remove(gearbox);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<GearboxDTO>> GetAll()
        {
            var gearboxes = await _dbContext.Gearboxes.ToListAsync();
            var gearboxDTOs = _mapper.Map<List<GearboxDTO>>(gearboxes);
            return gearboxDTOs;
        }

        public async Task<GearboxDTO> GetById(int id)
        {
            var gearbox = await _dbContext.Gearboxes.FirstOrDefaultAsync(o => o.Id == id) ?? throw new NotFoundException("Gearbox not found");
            var gearboxDTO = _mapper.Map<GearboxDTO>(gearbox);
            return gearboxDTO;
        }

        public async Task Update(int id, UpdateGearboxDTO dto)
        {
            var gearbox = await _dbContext.Gearboxes.FirstOrDefaultAsync(o => o.Id == id);
            if (gearbox == null)
                throw new NotFoundException("Gearbox not found");

            gearbox.Name = dto.Name;
            gearbox.NumberOfGears = dto.NumberOfGears;
            gearbox.TypeOfGearbox = dto.TypeOfGearbox;

            await _dbContext.SaveChangesAsync();
        }
    }
}
