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
    public class BrakeService : IBrakeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public BrakeService(ApplicationDbContext dbContext,IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> Create(CreateBrakeDTO dto)
        {
            var brake = _mapper.Map<Brake>(dto);
            await _dbContext.AddAsync(brake);
            await _dbContext.SaveChangesAsync();
            return brake.Id;
        }

        public async Task Delete(int id)
        {
            var brake = await _dbContext.Brakes.FirstOrDefaultAsync(o => o.Id == id);
            if (brake == null)
                throw new NotFoundException("Brake not found");
            _dbContext.Remove(brake);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<BrakeDTO>> GetAll()
        {
            var brakes = await _dbContext.Brakes.ToListAsync() ?? throw new NotFoundException("Brakes not found");
            var brakeDTOs = _mapper.Map<List<BrakeDTO>>(brakes);
            return brakeDTOs;
        }

        public async Task<BrakeDTO> GetById(int id)
        {
            var brake = await _dbContext.Brakes.FirstOrDefaultAsync(o => o.Id == id) ?? throw new NotFoundException("Brake not found");
            var brakeDTO = _mapper.Map<BrakeDTO>(brake);
            return brakeDTO;
        }

        public async Task Update(int id, UpdateBrakeDTO dto)
        {
            var brake = await _dbContext.Brakes.FirstOrDefaultAsync(o => o.Id == id) ?? throw new NotFoundException("Brake not found");
            brake.Type= dto.Type;
            await _dbContext.SaveChangesAsync();
        }
    }
}
