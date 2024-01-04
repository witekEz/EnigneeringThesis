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
    public class BrakeService : IBrakeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public BrakeService(ApplicationDbContext dbContext,IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int Create(CreateBrakeDTO dto)
        {
            var brake = _mapper.Map<Brake>(dto);
            _dbContext.Add(brake);
            _dbContext.SaveChanges();
            return brake.Id;
        }

        public void Delete(int id)
        {
            var brake = _dbContext.Brakes.FirstOrDefault(o => o.Id == id);
            if (brake == null)
                throw new NotFoundException("Brake not found");
            _dbContext.Remove(brake);
            _dbContext.SaveChanges();
        }

        public List<BrakeDTO> GetAll()
        {
            var brakes = _dbContext.Brakes.ToList();
            if (brakes == null)
                throw new NotFoundException("Brakes not found");
            var brakeDTOs = _mapper.Map<List<BrakeDTO>>(brakes);
            return brakeDTOs;
        }

        public BrakeDTO GetById(int id)
        {
            var brake = _dbContext.Brakes.FirstOrDefault(o => o.Id == id);
            if (brake == null)
                throw new NotFoundException("Brake not found");
            var brakeDTO = _mapper.Map<BrakeDTO>(brake);
            return brakeDTO;
        }

        public void Update(int id, UpdateBrakeDTO dto)
        {
            var brake = _dbContext.Brakes.FirstOrDefault(o => o.Id == id);
            if (brake == null)
                throw new NotFoundException("Brake not found");

            brake.Type= dto.Type;
            _dbContext.SaveChanges();
        }
    }
}
