using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Read;
using UA.Model.DTOs.Update;

namespace UA.Services.Interfaces
{
    public interface IGenerationService
    {
        Task<GenerationDTO> GetById(int modelId,int generationId);
        Task<List<GenerationDTO>> GetAll(int modelId);
        Task<int> Create(int modelId,CreateGenerationDTO dto);
        Task Update(UpdateGenerationDTO dto, int id);
        Task Delete(int modelId,int generationId);
    }
}
