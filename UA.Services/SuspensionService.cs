using AutoMapper;
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
    public class SuspensionService : ISuspensionService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public SuspensionService(ApplicationDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int Create(CreateSuspensionDTO dto)
        {
            var suspension = _mapper.Map<Suspension>(dto);
            _dbContext.Add(suspension);
            _dbContext.SaveChanges();
            return suspension.Id;
        }

        public void Delete(int id)
        {
            var suspension = _dbContext.Suspensions.FirstOrDefault(o => o.Id == id);
            if (suspension == null)
                throw new NotFoundException("Engine not found");
            _dbContext.Remove(suspension);
            _dbContext.SaveChanges();
        }

        public List<SuspensionDTO> GetAll()
        {
            var suspensions = _dbContext.Suspensions.ToList();
            if (suspensions == null)
                throw new NotFoundException("Suspensions not found");
            var suspensionDTOs = _mapper.Map<List<SuspensionDTO>>(suspensions);
            return suspensionDTOs;
        }

        public SuspensionDTO GetById(int id)
        {
            var suspension = _dbContext.Suspensions.FirstOrDefault(o => o.Id == id);
            if (suspension == null)
                throw new NotFoundException("Suspension not found");
            var suspensionDTO = _mapper.Map<SuspensionDTO>(suspension);
            return suspensionDTO;
        }

        public void Update(int id, UpdateSuspensionDTO dto)
        {
            var suspension = _dbContext.Suspensions.FirstOrDefault(o => o.Id == id);
            if (suspension == null)
                throw new NotFoundException("Suspension not found");
            if(dto.Type!=null)
                suspension.Type=dto.Type;
            _dbContext.SaveChanges();
        }
    }
}
