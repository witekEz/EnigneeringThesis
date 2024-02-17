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
    public class BodyColourService : IBodyColourService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public BodyColourService(ApplicationDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int Create(CreateBodyColourDTO dto)
        {
            var bodyColour = _mapper.Map<BodyColour>(dto);
            _dbContext.Add(bodyColour);
            _dbContext.SaveChanges();
            return bodyColour.Id;
        }

        public void Delete(int id)
        {
            var bodyColour = _dbContext.BodyColours.FirstOrDefault(o => o.Id == id);
            if (bodyColour == null)
                throw new NotFoundException("Body colour not found");
            _dbContext.Remove(bodyColour);
            _dbContext.SaveChanges();
        }

        public List<BodyColourDTO> GetAll()
        {
            var bodyColours = _dbContext.BodyColours.ToList();
            if (bodyColours == null)
                throw new NotFoundException("Body colours not found");
            var bodyColourDTOs = _mapper.Map<List<BodyColourDTO>>(bodyColours);
            return bodyColourDTOs;
        }

        public BodyColourDTO GetById(int id)
        {
            var bodyColour = _dbContext.BodyColours.FirstOrDefault(o => o.Id == id);
            if (bodyColour == null)
                throw new NotFoundException("Body colour not found");
            var bodyColourDTOs = _mapper.Map<BodyColourDTO>(bodyColour);
            return bodyColourDTOs;
        }

        public void Update(int id, UpdateBodyColourDTO dto)
        {
            var bodyColour = _dbContext.BodyColours.FirstOrDefault(o => o.Id == id);
            if (bodyColour == null)
                throw new NotFoundException("Body colour not found");

            bodyColour.Colour = dto.Colour;
            bodyColour.ColourCode = dto.ColourCode;
            _dbContext.SaveChanges();
        }
    }
}
