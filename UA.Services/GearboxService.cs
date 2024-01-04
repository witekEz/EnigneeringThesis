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
    public class GearboxService : IGearboxService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GearboxService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int Create(CreateGearboxDTO dto)
        {
            var gearbox = _mapper.Map<Gearbox>(dto);
            _dbContext.Add(gearbox);
            _dbContext.SaveChanges();
            return gearbox.Id;
        }

        public void Delete(int id)
        {
            var gearbox = _dbContext.Gearboxes.FirstOrDefault(o => o.Id == id);
            if (gearbox == null)
                throw new NotFoundException("Gearbox not found");
            _dbContext.Remove(gearbox);
            _dbContext.SaveChanges();
        }

        public List<GearboxDTO> GetAll()
        {
            var gearboxes = _dbContext.Gearboxes.ToList();
            var gearboxDTOs = _mapper.Map<List<GearboxDTO>>(gearboxes);
            return gearboxDTOs;
        }

        public GearboxDTO GetById(int id)
        {
            var gearbox = _dbContext.Gearboxes.FirstOrDefault(o => o.Id == id);
            if (gearbox == null)
                throw new NotFoundException("Gearbox not found");
            var gearboxDTO = _mapper.Map<GearboxDTO>(gearbox);
            return gearboxDTO;
        }

        public void Update(int id, UpdateGearboxDTO dto)
        {
            var gearbox = _dbContext.Gearboxes.FirstOrDefault(o => o.Id == id);
            if (gearbox == null)
                throw new NotFoundException("Gearbox not found");

            gearbox.Name = dto.Name;
            gearbox.NumberOfGears = dto.NumberOfGears;
            gearbox.TypeOfGearbox = dto.TypeOfGearbox;
            gearbox.Rate = dto.Rate;

            _dbContext.SaveChanges();
        }
    }
}
