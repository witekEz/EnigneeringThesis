using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.DAL.EF;
using UA.Model.DTOs;
using UA.Model.Entities;
using UA.Model.DTOs.Create;
using UA.Services.Interfaces;
using UA.Model.DTOs.Update;
using Microsoft.Extensions.Logging;
using UA.Services.Middleware.Exceptions;
using Microsoft.AspNetCore.StaticFiles;

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
        public void Delete(int modelId, int generationId)
        {
            _logger.LogError($"Generation with ID: {generationId} DELETE action invoked");
            var model = _dbContext
                .Models
                .FirstOrDefault(g => g.Id == modelId);
            if (model == null)
                throw new NotFoundException("Model not found");

            var generation = _dbContext.Generations.FirstOrDefault(m => m.Id == generationId);
            if (generation == null || generation.Model.Id != modelId)
                throw new NotFoundException("Generation not found");

            _dbContext.Generations.Remove(generation);
            _dbContext.SaveChanges();
        }
        public GenerationDTO GetById(int modelId, int generationId)
        {
            _logger.LogError($"Generation with ID:{generationId} GET action invoked");
            var model = _dbContext.Models.FirstOrDefault(m => m.Id == modelId);
            if (model is null)
                throw new NotFoundException("Model not found");

            var generation = _dbContext.Generations
               .Include(b => b.GenerationImages)
               .Include(b => b.BodyTypes)
               .Include(b => b.Drivetrains)
               .Include(b => b.Engines)
               .Include(b => b.Gearboxes)
               .Include(b => b.DetailedInfo)
               .Include(b => b.DetailedInfo.Suspensions)
               .Include(b => b.DetailedInfo.BodyColours)
               .Include(b => b.DetailedInfo.Brakes)
               .Include(b => b.OptionalEquipment)
               .Include(b => b.Model)
               .Include(b => b.Model.Brand)
               .FirstOrDefault(p => p.Id == generationId);

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
        public List<GenerationDTO> GetAll(int modelId)
        {
            _logger.LogError($"Generations GET action invoked");
            var model = _dbContext.Models
                .Include(g=>g.Generations)
                .FirstOrDefault(m => m.Id == modelId);
            if (model == null)
                throw new NotFoundException("Model not found");

            var generationsDTOs = _mapper.Map<List<GenerationDTO>>(model.Generations);
            return generationsDTOs;
        }
        public int Create(int modelId, CreateGenerationDTO dto)
        {
            _logger.LogError($"Generation object: {dto} POST action invoked");
            var model = _dbContext
                .Models
                .FirstOrDefault(n => n.Id == modelId);
            if (model == null)
                throw new NotFoundException("Model not found");

            var generationEntity = _mapper.Map<Generation>(dto);
            generationEntity.Model.Id = modelId;
            _dbContext.Generations.Add(generationEntity);
            _dbContext.SaveChanges();
            return generationEntity.Id;
        }
        public void Update(UpdateGenerationDTO dto, int id)
        {
            _logger.LogError($"Generation with ID: {id} UPDATE action invoked");
            var generation = _dbContext
                .Generations
                .FirstOrDefault(g => g.Id == id);
            if (generation == null) 
                throw new NotFoundException("Generation not found");
            
            generation.Category = dto.Category;
            generation.Name = dto.Name;
            generation.MinPrice = dto.MaxPrice;
            generation.Rate = dto.Rate;
            _dbContext.SaveChanges();
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
