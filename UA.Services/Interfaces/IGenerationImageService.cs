using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Services.Interfaces
{
    public interface IGenerationImageService
    {
        Task Upload(int generationId,IFormFile image);
    }
}
