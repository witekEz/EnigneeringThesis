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
    public interface IBodyService
    {
        Task<List<BodyDTO>> GetAll(int generationId);
        Task<BodyDTO> GetById(int generationId, int id);
        Task<int> Create(int generationId,CreateBodyDTO dto);
        Task Delete(int generationId, int id);
        Task Update(int id,UpdateBodyDTO bodyTypeDTO);
    }
}
