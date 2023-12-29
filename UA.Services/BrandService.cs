using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    public class BrandService:IBrandService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<BrandService> _logger;
        private readonly IMapper _mapper;
        public BrandService(ApplicationDbContext dbContext, ILogger<BrandService> logger, IMapper mapper) {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public int Create(CreateBrandDTO brandDTO)
        {
            var brand=_mapper.Map<Brand>(brandDTO);
            _dbContext.Brands.Add(brand);
            _dbContext.SaveChanges();
            return brand.Id;
        }

        public void Delete(int id)
        {
            var brand=_dbContext.Brands.FirstOrDefault(n => n.Id == id);
            if(brand is null)
            {
                throw new NotFoundException("Brand not found");
            }
            _dbContext.Remove(brand);
            _dbContext.SaveChanges();

        }

        public IEnumerable<BrandDTO> GetAll()
        {
            var brands=_dbContext.Brands.ToList();
            var brandsDTO=_mapper.Map<List<BrandDTO>>(brands);
            return brandsDTO;
        }

        public BrandDTO GetById(int id)
        {
            var brand= _dbContext.Brands.Include(m => m.Models).FirstOrDefault(n => n.Id == id);
            var brandDTO= _mapper.Map<BrandDTO>(brand);
            return brandDTO;
        }

        public void Update(int id, UpdateBrandDTO brandDTO)
        {
            var brand=_dbContext.Brands.FirstOrDefault(n=>n.Id==id);
            if(brand is null) 
            { 
                throw new NotFoundException("Brand not found"); 
            }
            brand.Name = brandDTO.Name;
            brand = _mapper.Map(brandDTO, brand);
            _dbContext.SaveChanges();
            
        }
    }
}
