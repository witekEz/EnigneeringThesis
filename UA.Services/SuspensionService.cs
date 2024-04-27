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
    public class SuspensionService : ISuspensionService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public SuspensionService(ApplicationDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> Create(CreateSuspensionDTO dto)
        {
            var suspension = _mapper.Map<Suspension>(dto);
            await _dbContext.AddAsync(suspension);
            await _dbContext.SaveChangesAsync();
            return suspension.Id;
        }

        public async Task Delete(int id)
        {
            var suspension = await _dbContext.Suspensions.FirstOrDefaultAsync(o => o.Id == id) ?? throw new NotFoundException("Engine not found");
            _dbContext.Remove(suspension);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<SuspensionDTO>> GetAll()
        {
            var suspensions = await _dbContext.Suspensions.ToListAsync() ?? throw new NotFoundException("Suspensions not found");
            var suspensionDTOs = _mapper.Map<List<SuspensionDTO>>(suspensions);
            return suspensionDTOs;
        }

        public async Task<SuspensionDTO> GetById(int id)
        {
            var suspension = await _dbContext.Suspensions.FirstOrDefaultAsync(o => o.Id == id) ?? throw new NotFoundException("Suspension not found");
            var suspensionDTO = _mapper.Map<SuspensionDTO>(suspension);
            return suspensionDTO;
        }

        public async Task Update(int id, UpdateSuspensionDTO dto)
        {
            var suspension = await _dbContext.Suspensions.FirstOrDefaultAsync(o => o.Id == id) ?? throw new NotFoundException("Suspension not found");
            if (dto.Type!=null)
                suspension.Type=dto.Type;
            await _dbContext.SaveChangesAsync();
        }
    }
}
