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
    public interface IEngineService
    {
        Task<List<EngineDTO>> GetAll();
        Task<EngineDTO> GetById(int id);
        Task<int> Create(CreateEngineDTO dto);
        Task Update(int id,UpdateEngineDTO dto);
        Task Delete(int id);
    }
}
