using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        public async Task<int> Create(CreateBrandDTO brandDTO)
        {
            var brand=_mapper.Map<Brand>(brandDTO);
            await _dbContext.Brands.AddAsync(brand);
            await _dbContext.SaveChangesAsync();
            return brand.Id;
        }

        public async Task Delete(int id)
        {
            var brand=await _dbContext.Brands.FirstOrDefaultAsync(n => n.Id == id) ?? throw new NotFoundException("Brand not found");
            _dbContext.Remove(brand);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<BrandDTO>> GetAll()
        {
            var brands=await _dbContext.Brands.ToListAsync();
            var brandsDTO=_mapper.Map<List<BrandDTO>>(brands);
            return brandsDTO;
        }

        public async Task<BrandDTO> GetById(int id)
        {
            var brand= await _dbContext.Brands.FirstOrDefaultAsync(n => n.Id == id);
            var brandDTO= _mapper.Map<BrandDTO>(brand);
            return brandDTO;
        }

        public async Task Update(int id, UpdateBrandDTO brandDTO)
        {
            var brand=await _dbContext.Brands.FirstOrDefaultAsync(n=>n.Id==id) ?? throw new NotFoundException("Brand not found");
            brand.Name = brandDTO.Name;
            brand = _mapper.Map(brandDTO, brand);
            await _dbContext.SaveChangesAsync();
            
        }
    }
}
