using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;

namespace UA.Services.Interfaces
{
    public interface IGenerationService
    {
        GenerationDTO GetById(int id);
        IEnumerable<GenerationDTO> GetAll();
        int Create(CreateGenerationDTO dto);
        bool Update(UpdateGenerationDTO dto, int id);
        bool Delete(int id);
    }
}
