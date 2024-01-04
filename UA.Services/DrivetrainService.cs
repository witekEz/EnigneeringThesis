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
    public class DrivetrainService:IDrivetrainService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public DrivetrainService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(CreateDrivetrainDTO dto)
        {
            var drivetrain = _mapper.Map<Drivetrain>(dto);
            _dbContext.Add(drivetrain);
            _dbContext.SaveChanges();
            return drivetrain.Id;
        }

        public void Delete(int id)
        {
            var drivetrain = _dbContext.Drivetrains.FirstOrDefault(o => o.Id == id);
            if (drivetrain == null)
                throw new NotFoundException("Drivetrain not found");
            _dbContext.Remove(drivetrain);
            _dbContext.SaveChanges();
        }

        public List<DrivetrainDTO> GetAll()
        {
            var drivetrains = _dbContext.Drivetrains.ToList();
            if (drivetrains is null)
            {
                throw new NotFoundException("Drivetrains not found");
            }
            var drivetrainDTOs = _mapper.Map<List<DrivetrainDTO>>(drivetrains);
            return drivetrainDTOs;
        }

        public DrivetrainDTO GetById(int id)
        {
            var drivetrain = _dbContext.Drivetrains.FirstOrDefault(o => o.Id == id);
            if (drivetrain == null)
                throw new NotFoundException("Drivetrain not found");
            var drivetrainDTO = _mapper.Map<DrivetrainDTO>(drivetrain);
            return drivetrainDTO;
        }

        public void Update(int id, UpdateDrivetrainDTO dto)
        {
            var drivetrain = _dbContext.Drivetrains.FirstOrDefault(o => o.Id == id);
            if (drivetrain == null)
                throw new NotFoundException("Drivetrain not found");

            drivetrain.Type= dto.Type;
            _dbContext.SaveChanges();
        }
    }
}
