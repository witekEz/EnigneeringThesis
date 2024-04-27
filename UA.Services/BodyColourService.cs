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
    public class BodyColourService : IBodyColourService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public BodyColourService(ApplicationDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> Create(CreateBodyColourDTO dto)
        {
            var bodyColour = _mapper.Map<BodyColour>(dto);
            await _dbContext.AddAsync(bodyColour);
            await _dbContext.SaveChangesAsync();
            return bodyColour.Id;
        }

        public async Task Delete(int id)
        {
            var bodyColour = await _dbContext.BodyColours.FirstOrDefaultAsync(o => o.Id == id);
            if (bodyColour == null)
                throw new NotFoundException("Body colour not found");
            _dbContext.Remove(bodyColour);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<BodyColourDTO>> GetAll()
        {
            var bodyColours = await _dbContext.BodyColours.ToListAsync();
            if (bodyColours == null)
                throw new NotFoundException("Body colours not found");
            var bodyColourDTOs = _mapper.Map<List<BodyColourDTO>>(bodyColours);
            return bodyColourDTOs;
        }

        public async Task<BodyColourDTO> GetById(int id)
        {
            var bodyColour = await _dbContext.BodyColours.FirstOrDefaultAsync(o => o.Id == id);
            if (bodyColour == null)
                throw new NotFoundException("Body colour not found");
            var bodyColourDTOs = _mapper.Map<BodyColourDTO>(bodyColour);
            return bodyColourDTOs;
        }

        public async Task Update(int id, UpdateBodyColourDTO dto)
        {
            var bodyColour = await _dbContext.BodyColours.FirstOrDefaultAsync(o => o.Id == id);
            if (bodyColour == null)
                throw new NotFoundException("Body colour not found");

            bodyColour.Colour = dto.Colour;
            bodyColour.ColourCode = dto.ColourCode;
            await _dbContext.SaveChangesAsync();
        }
    }
}
