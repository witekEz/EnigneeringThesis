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
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public CategoryService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public async Task<int> Create(CreateCategoryDTO dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category.Id;

        }

        public async Task Delete(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(o => o.Id == id) ?? throw new NotFoundException("Category not found");
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<CategoryDTO>> GetAll()
        {
            var categories= await _dbContext.Categories.ToListAsync();
            if (categories == null) {
                throw new NotFoundException("Categories not found");
            }
            var categoryDTOs=_mapper.Map<List<CategoryDTO>>(categories);
            return categoryDTOs;
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var category=await _dbContext.Categories.FirstOrDefaultAsync(o=>o.Id==id) ?? throw new NotFoundException("Category not found");
            var categoryDTO = _mapper.Map<CategoryDTO>(category);
            return categoryDTO;
        }

        public async Task Update(int id, UpdateCategoryDTO dto)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(o => o.Id == id) ?? throw new NotFoundException("Category not found");
            category.Name = dto.Name;
            await _dbContext.SaveChangesAsync();
        }
    }
}
