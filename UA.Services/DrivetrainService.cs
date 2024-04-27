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
    public class DrivetrainService:IDrivetrainService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public DrivetrainService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> Create(CreateDrivetrainDTO dto)
        {
            var drivetrain = _mapper.Map<Drivetrain>(dto);
            await _dbContext.AddAsync(drivetrain);
            await _dbContext.SaveChangesAsync();
            return drivetrain.Id;
        }

        public async Task Delete(int id)
        {
            var drivetrain = await _dbContext.Drivetrains.FirstOrDefaultAsync(o => o.Id == id);
            if (drivetrain == null)
                throw new NotFoundException("Drivetrain not found");
            _dbContext.Remove(drivetrain);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<DrivetrainDTO>> GetAll()
        {
            var drivetrains = await _dbContext.Drivetrains.ToListAsync() ?? throw new NotFoundException("Drivetrains not found");
            var drivetrainDTOs = _mapper.Map<List<DrivetrainDTO>>(drivetrains);
            return drivetrainDTOs;
        }

        public async Task<DrivetrainDTO> GetById(int id)
        {
            var drivetrain = await _dbContext.Drivetrains.FirstOrDefaultAsync(o => o.Id == id) ?? throw new NotFoundException("Drivetrain not found");
            var drivetrainDTO = _mapper.Map<DrivetrainDTO>(drivetrain);
            return drivetrainDTO;
        }

        public async Task Update(int id, UpdateDrivetrainDTO dto)
        {
            var drivetrain = await _dbContext.Drivetrains.FirstOrDefaultAsync(o => o.Id == id) ?? throw new NotFoundException("Drivetrain not found");
            drivetrain.Type= dto.Type;
            await _dbContext.SaveChangesAsync();
        }
    }
}
