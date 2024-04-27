using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;
using UA.Model.DTOs.Read;

namespace UA.Services.Interfaces
{
    public interface ISuspensionService
    {
        Task<List<SuspensionDTO>> GetAll();
        Task<SuspensionDTO> GetById(int id);
        Task<int> Create(CreateSuspensionDTO dto);
        Task Update(int id, UpdateSuspensionDTO dto);
        Task Delete(int id);
    }
}
