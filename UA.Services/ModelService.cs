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
        public int Create(int brandId, CreateModelDTO dto)
        {
            var brand = _dbContext.Brands.FirstOrDefault(n=>n.Id==brandId);

            if (brand == null) {
                throw new NotFoundException("Brand not found"); }

            var modelEntity = _mapper.Map<Model.Entities.Model>(dto);
            modelEntity.BrandId = brandId;
            _dbContext.Models.Add(modelEntity);
            _dbContext.SaveChanges();
            return modelEntity.Id;
        }

        public ModelDTO GetById(int brandId, int modelId)
        {
            var brand=_dbContext.Brands.FirstOrDefault(n=>n.Id==brandId);
            if(brand is null)
            {
                throw new NotImplementedException("Brand not found");
            }
            var model=_dbContext.Models.FirstOrDefault(n=>n.Id==modelId);
            if (model is null || model.BrandId!=brandId)
            {
                throw new NotFoundException("Model not found");
            }
            var modelDTO=_mapper.Map<ModelDTO>(model);
            return modelDTO;
        }
        public List<ModelDTO> GetAll(int brandId)
        {
            var brand = _dbContext.Brands
                .Include(m=>m.Models)
                .FirstOrDefault(n => n.Id == brandId);
            if (brand is null)
            {
                throw new NotFoundException("Brand not found");
            }
           
            var modelDTOs = _mapper.Map<List<ModelDTO>>(brand.Models);
            return modelDTOs;
        }

        public void Delete(int brandId, int modelId)
        {
            var brand=_dbContext.Brands.FirstOrDefault(b=>b.Id==brandId);
            if (brand is null)
                throw new NotFoundException("Brand not found");
            var model = _dbContext.Models.FirstOrDefault(m => m.Id == modelId);
            if(model is null || model.BrandId!=brandId)
            {
                throw new NotFoundException("Model not found");
            }
            _dbContext.Models.Remove(model);
            _dbContext.SaveChanges();
        }

        public void Update(int id, UpdateModelDTO dto)
        {
            var model = _dbContext.Models.FirstOrDefault(o=>o.Id==id);
            if (model == null)
                throw new NotFoundException("Model type not found");

            model.Name = dto.Name;

            _dbContext.SaveChanges();
        }
    }
}
