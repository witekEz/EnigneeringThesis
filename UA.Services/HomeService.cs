using AutoMapper;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UA.DAL.EF;
using UA.Model.DTOs;
using UA.Model.Entities;
using UA.Model.Queries;
using UA.Services.Interfaces;
using UA.Services.Middleware.Exceptions;

namespace UA.Services
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public HomeService(ApplicationDbContext dbContext, IMapper mapper) {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public PageResult<GenerationDTO> GetAll(GenerationQuery query)
        {
            string [] filterBrands= { };
            string [] filterCategories= { };
            string [] filterBodyTypes= { };
            if (query.FilterBrands != null)
            {
                filterBrands = query.FilterBrands.ToLower().Split(',');
            }
            if (query.FilterCategories != null)
            {
                filterCategories = query.FilterCategories.Split(',');
            }
            if (query.FilterBodyTypes != null)
            {
                filterBodyTypes = query.FilterBodyTypes.Split(',');
            }

            var queryBase = _dbContext
                .Generations
                .Include(b => b.GenerationImages)
                .Include(b => b.Model)
                .Include(b => b.Bodies)
                .ThenInclude(b => b.BodyType)
                .Include(b => b.Category)
                .Include(b => b.Model.Brand)
                .Where(o => query.Search == null ||
                        (o.Name.ToLower().Contains(query.Search.ToLower()) ||
                         o.Model.Name.ToLower().Contains(query.Search.ToLower()) ||
                         o.Model.Brand.Name.ToLower().Contains(query.Search.ToLower()))
                         )
                .Where(o => query.FilterBrands == null || (filterBrands.Any(brand => brand == o.Model.Brand.Name)))
                .Where(o => query.FilterCategories == null || (filterCategories.Any(category => category == o.Category.Name)))
                .Where(o => query.FilterBodyTypes == null || (o.Bodies.Any(el => filterBodyTypes.Contains(el.BodyType.Name))))
                .Where(o => query.MaxPrice == null || (o.MaxPrice <= query.MaxPrice))
                .Where(o => query.MinPrice == null || (o.MinPrice >= query.MinPrice))
                .Where(o => query.Rate == null || (o.Rate >= query.Rate));



            var totalItemsCount = queryBase.Count();

            if(!string.IsNullOrEmpty(query.SortBy))
            {
                var columnSelectors = new Dictionary<string, Expression<Func<Generation, object>>>
                {
                    {nameof(Generation.Name),r=>r.Name },
                    {nameof(Generation.MinPrice),r=>r.MinPrice },
                    {nameof(Generation.MaxPrice),r=>r.MaxPrice },
                };
                var selectedColumn = columnSelectors[query.SortBy];
                queryBase=query.SortDirection==SortDirectionEnum.ASC
                    ? queryBase.OrderBy(selectedColumn) 
                    : queryBase.OrderByDescending(selectedColumn);
            }

            var generations = queryBase
                .Skip(query.PageSize*(query.PageNumber-1))
                .Take(query.PageSize)
                .ToList();
            if (generations is null)
            {
                throw new NotFoundException("Generation not found");
            }
            
           
            var generationDTOs = _mapper.Map<List<GenerationDTO>>(generations);
            var generationDtoLen= generationDTOs.Count();
            var d = 0;

            generations.ForEach(gener => {                   
                generationDTOs[d].Images = new List<GenerationImageDTO>() { };
                if (gener.GenerationImages != null)
                {
                    for (int i = 0; i < gener.GenerationImages.Count; i++)
                    {
                        var imageDTO = new GenerationImageDTO()
                        {
                            Id = gener.GenerationImages[i].Id,
                            Image = this.GetImage(gener.GenerationImages[i].ImageGUID),
                        };
                        if (!imageDTO.Image.SequenceEqual(new byte[0])) 
                        {
                            generationDTOs[d].Images.Add(imageDTO);
                        }               
                    }
                }
                d++;
            });              
            var pageResult= new PageResult<GenerationDTO>(generationDTOs,totalItemsCount,query.PageSize,query.PageNumber);
            return pageResult;

        }

        public GenerationDTO GetById(int id)
        {
            var generation=_dbContext
                .Generations
                .Include(b => b.GenerationImages)
                .Include(b => b.Bodies)
                .Include(b=>b.Category)
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
                .FirstOrDefault(g=> g.Id == id);
            if (generation is null)
            {
                throw new NotFoundException("Generation not found");
            }
            var generationDTO=_mapper.Map<GenerationDTO>(generation);
            generationDTO.Images = new List<GenerationImageDTO>() { };
            if (generation.GenerationImages != null)
            {
                for (int i = 0; i < generation.GenerationImages.Count; i++)
                {
                    var imageDTO = new GenerationImageDTO()
                    {
                        Id = generation.GenerationImages[i].Id,
                        Image = this.GetImage(generation.GenerationImages[i].ImageGUID),
                    };
                    generationDTO.Images.Add(imageDTO);
                }
            }
            return generationDTO;
        }
        private byte[] GetImage(Guid name)
        {
            byte[] bytes = new byte[0];
            var rootPath = Directory.GetCurrentDirectory();
            var imagesFolder = Path.Combine(rootPath, "wwwroot", "images");
            var fileName = name.ToString() + ".jpg";
            var filePath = $"{imagesFolder}/{fileName}";
            var fileExsist = System.IO.File.Exists(filePath);
            if (!fileExsist)
            {
                return bytes;
            }
            var fileContent = System.IO.File.ReadAllBytes(filePath);
            return fileContent;
        }
    }
}
