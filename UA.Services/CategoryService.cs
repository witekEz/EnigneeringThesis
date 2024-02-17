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
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public CategoryService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public int Create(CreateCategoryDTO dto)
        {
            var category = _mapper.Map<Category>(dto);
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return category.Id;

        }

        public void Delete(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(o => o.Id == id);
            if (category == null)
                throw new NotFoundException("Category not found");
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }

        public List<CategoryDTO> GetAll()
        {
            var categories= _dbContext.Categories.ToList();
            if (categories == null) {
                throw new NotFoundException("Categories not found");
            }
            var categoryDTOs=_mapper.Map<List<CategoryDTO>>(categories);
            return categoryDTOs;
        }

        public CategoryDTO GetById(int id)
        {
            var category=_dbContext.Categories.FirstOrDefault(o=>o.Id==id);
            if (category == null){
                throw new NotFoundException("Category not found");
            }
            var categoryDTO = _mapper.Map<CategoryDTO>(category);
            return categoryDTO;
        }

        public void Update(int id, UpdateCategoryDTO dto)
        {
            var category = _dbContext.Categories.FirstOrDefault(o => o.Id == id);
            if (category == null){
                throw new NotFoundException("Category not found");
            }
            category.Name = dto.Name;
            _dbContext.SaveChanges();
        }
    }
}
