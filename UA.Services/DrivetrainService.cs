using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.DAL.EF;
using UA.Model.DTOs;
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
    }
}
