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
    public interface IGearboxService
    {
        Task<List<GearboxDTO>> GetAll();
        Task<GearboxDTO> GetById(int id);
        Task<int> Create(CreateGearboxDTO dto);
        Task Update(int id, UpdateGearboxDTO dto);
        Task Delete(int id);
    }
}
