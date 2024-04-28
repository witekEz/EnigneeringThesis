using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.DAL.EF;
using UA.Model.Entities;
using UA.Model.DTOs.Create;
using UA.Services.Interfaces;
using UA.Model.DTOs.Update;
using Microsoft.Extensions.Logging;
using UA.Services.Middleware.Exceptions;
using Microsoft.AspNetCore.StaticFiles;
using UA.Model.DTOs.Read;

namespace UA.Services
{
    public class GenerationService : IGenerationService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<GenerationService> _logger;
        public GenerationService(ApplicationDbContext dbContext, IMapper mapper, ILogger<GenerationService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task Delete(int modelId, int generationId)
        {
            var model = await _dbContext
                .Models
                .FirstOrDefaultAsync(g => g.Id == modelId) ?? throw new NotFoundException("Model not found");
            var generation = await _dbContext.Generations.FirstOrDefaultAsync(m => m.Id == generationId);
            if (generation == null || generation.Model.Id != modelId)
                throw new NotFoundException("Generation not found");

            _dbContext.Generations.Remove(generation);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<GenerationDTO> GetById(int modelId, int generationId)
        {
            var model = await _dbContext.Models.FirstOrDefaultAsync(m => m.Id == modelId) ?? throw new NotFoundException("Model not found");
            var generation = await _dbContext.Generations
               /*.Include(b => b.GenerationImages)
               .Include(b => b.AvgRateGeneration)
               .Include(b => b.Category)
               .Include(b => b.Bodies)
               .Include(b => b.Bodies)
                .ThenInclude(bt=>bt.BodyType)
               .Include(b => b.Drivetrains)
               .Include(b => b.Engines)
                .ThenInclude(r => r.AvgRateEngine)
               .Include(b => b.Gearboxes)
                .ThenInclude(r => r.AvgRateGearbox)
               .Include(b => b.DetailedInfo)
               .Include(b => b.DetailedInfo.Suspensions)
               .Include(b => b.DetailedInfo.BodyColours)
               .Include(b => b.DetailedInfo.Brakes)
               .Include(b => b.OptionalEquipment)
               .Include(b => b.Model)
               .Include(b => b.Model.Brand)*/
               .FirstOrDefaultAsync(p => p.Id == generationId);

            if (generation == null|| generation.Model.Id != modelId) 
                throw new NotFoundException("Generation not found");
           
            
            var generationDTO = _mapper.Map<GenerationDTO>(generation);
            generationDTO.Images = new List<GenerationImageDTO>() { };
            if (generation.GenerationImages!=null)
            {
                for (int i = 0; i < generation.GenerationImages.Count; i++)
                {
                    var imageDTO=new GenerationImageDTO()
                    {
                        Id= generation.GenerationImages[i].Id,
                        Image = this.GetImage(generation.GenerationImages[i].ImageGUID),
                    };
                    if (!imageDTO.Image.SequenceEqual(new byte[0]))
                    {
                        generationDTO.Images.Add(imageDTO);
                    }
                    
                }
            }
           
            return generationDTO;
        }
        public async Task<List<GenerationDTO>> GetAll(int modelId)
        {
            var model = await _dbContext.Models
                .FirstOrDefaultAsync(m => m.Id == modelId) ?? throw new NotFoundException("Model not found");
            var generationsDTOs = _mapper.Map<List<GenerationDTO>>(model.Generations);
            return generationsDTOs;
        }
        public async Task<int> Create(int modelId, CreateGenerationDTO dto)
        {
            var model = await _dbContext
                .Models
                .FirstOrDefaultAsync(n => n.Id == modelId) ?? throw new NotFoundException("Model not found");
            var generationEntity = _mapper.Map<Generation>(dto);

            generationEntity.Model = model;
            if (dto.Drivetrains.Count > 0)
            {
                var drivetrainsEntity = await _dbContext.Drivetrains.Where(data => dto.Drivetrains.Contains(data.Id)).ToListAsync();
                generationEntity.Drivetrains= drivetrainsEntity;
            }
            if (dto.Engines.Count > 0)
            {
                var enginesEntity = await _dbContext.Engines.Where(data => dto.Engines.Contains(data.Id)).ToListAsync();
                generationEntity.Engines = enginesEntity;
            }
            if (dto.Gearboxes.Count > 0)
            {
                var gearboxesEntity = await _dbContext.Gearboxes.Where(data => dto.Gearboxes.Contains(data.Id)).ToListAsync();
                generationEntity.Gearboxes = gearboxesEntity;
            }
            if(dto.DetailedInfo!=null  )
            {
                if(dto.DetailedInfo.Suspensions != null && dto.DetailedInfo.Suspensions.Count > 0)
                {
                    var suspensionsEntity = await _dbContext.Suspensions.Where(data => dto.DetailedInfo.Suspensions.Contains(data.Id)).ToListAsync();
                    if (generationEntity.DetailedInfo!=null)
                    {
                        generationEntity.DetailedInfo.Suspensions = suspensionsEntity;
                    }          
                }
                if (dto.DetailedInfo.BodyColours != null && dto.DetailedInfo.BodyColours.Count > 0)
                {
                    var bodyColoursEntity = await _dbContext.BodyColours.Where(data => dto.DetailedInfo.BodyColours.Contains(data.Id)).ToListAsync();
                    if (generationEntity.DetailedInfo != null)
                    {
                        generationEntity.DetailedInfo.BodyColours = bodyColoursEntity;
                    }
                }
                if (dto.DetailedInfo.Brakes != null && dto.DetailedInfo.Brakes.Count > 0)
                {
                    var brakesEntity = await _dbContext.Brakes.Where(data => dto.DetailedInfo.Brakes.Contains(data.Id)).ToListAsync();
                    if (generationEntity.DetailedInfo != null)
                    {
                        generationEntity.DetailedInfo.Brakes = brakesEntity;
                    }
                }
            }
            
            
            await _dbContext.Generations.AddAsync(generationEntity);
            await _dbContext.SaveChangesAsync();
            return generationEntity.Id;
        }
        public async Task Update(UpdateGenerationDTO dto, int id)
        {
            var generation = await _dbContext
                .Generations
                .FirstOrDefaultAsync(g => g.Id == id) ?? throw new NotFoundException("Generation not found");
            generation.Name = dto.Name;
            generation.MinPrice = dto.MinPrice;
            generation.MaxPrice = dto.MaxPrice;
            await _dbContext.SaveChangesAsync();
        }
        private byte[] GetImage(Guid name)
        {
            byte[] bytes = new byte[0];
            var rootPath = Directory.GetCurrentDirectory();
            var imagesFolder = Path.Combine(rootPath, "wwwroot", "images");
            var fileName = name.ToString() + ".jpg";
            var filePath = $"{imagesFolder}/{fileName}";
            var fileExsist= System.IO.File.Exists(filePath);
            if (!fileExsist)
            {
               return bytes;
            }
            var fileContent=System.IO.File.ReadAllBytes(filePath);
            return fileContent;
        }
    }
}
