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
    public interface IBrakeService
    {
        Task<List<BrakeDTO>> GetAll();
        Task<BrakeDTO> GetById(int id);
        Task<int> Create(CreateBrakeDTO dto);
        Task Update(int id, UpdateBrakeDTO dto);
        Task Delete(int id);
    }
}
