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
    public class ModelService:IModelService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public ModelService(ApplicationDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> Create(int brandId, CreateModelDTO dto)
        {
            var brand = await _dbContext.Brands.FirstOrDefaultAsync(n=>n.Id==brandId) ?? throw new NotFoundException("Brand not found");
            var modelEntity = _mapper.Map<Model.Entities.Model>(dto);
            modelEntity.BrandId = brandId;
            await _dbContext.Models.AddAsync(modelEntity);
            await _dbContext.SaveChangesAsync();
            return modelEntity.Id;
        }

        public async Task<ModelDTO> GetById(int brandId, int modelId)
        {
            var brand=await _dbContext.Brands.FirstOrDefaultAsync(n=>n.Id==brandId) ?? throw new NotImplementedException("Brand not found");
            var model =await _dbContext.Models.FirstOrDefaultAsync(n=>n.Id==modelId);
            if (model is null || model.BrandId!=brandId)
            {
                throw new NotFoundException("Model not found");
            }
            var modelDTO=_mapper.Map<ModelDTO>(model);
            return modelDTO;
        }
        public async Task<List<ModelDTO>> GetAll(int brandId)
        {
            var brand = await _dbContext.Brands
                //.Include(m=>m.Models)
                .FirstOrDefaultAsync(n => n.Id == brandId) ?? throw new NotFoundException("Brand not found");
            var modelDTOs = _mapper.Map<List<ModelDTO>>(brand.Models);
            return modelDTOs;
        }

        public async Task Delete(int brandId, int modelId)
        {
            var brand=await _dbContext.Brands.FirstOrDefaultAsync(b=>b.Id==brandId) ?? throw new NotFoundException("Brand not found");
            var model = await _dbContext.Models.FirstOrDefaultAsync(m => m.Id == modelId);
            if(model is null || model.BrandId!=brandId)
            {
                throw new NotFoundException("Model not found");
            }
            _dbContext.Models.Remove(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int id, UpdateModelDTO dto)
        {
            var model = await _dbContext.Models.FirstOrDefaultAsync(o=>o.Id==id) ?? throw new NotFoundException("Model type not found");
            model.Name = dto.Name;
            await _dbContext.SaveChangesAsync();
        }
    }
}
