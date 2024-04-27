using AutoMapper;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.DAL.EF;
using UA.Model.DTOs.Create;
using UA.Model.Entities;
using UA.Services.Interfaces;
using UA.Services.Middleware.Exceptions;

namespace UA.Services
{
    public class GenerationImageService : IGenerationImageService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GenerationImageService(ApplicationDbContext dbContext,IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task Upload(int generationId,IFormFile image)
        {
            if(image != null && image.Length > 0) 
            {
                var rootPath=Directory.GetCurrentDirectory();
                var uploadsFolder = Path.Combine(rootPath, "wwwroot","images");
                var newImageDTO=new CreateGenerationImageDTO() { GenerationId = generationId,ImageGUID=Guid.NewGuid()};
                
                var fileName=newImageDTO.ImageGUID.ToString() + ".jpg";
                var fullPath=Path.Combine(uploadsFolder, fileName);


                using var imageStream = Image.Load(image.OpenReadStream());
                imageStream.Mutate(x => x.Resize(600, 400));
                imageStream.Save(fullPath);

                //using (var stream=new FileStream(fullPath, FileMode.Create))
                //{
                //    image.CopyTo(stream);
                //}

                var newImage=_mapper.Map<GenerationImage>(newImageDTO);
                await _dbContext.AddAsync(newImage);
                await _dbContext.SaveChangesAsync();

            }
            else
            {
                throw new BadRequestException("Error while uploading image");
            }
        }
    }
}
