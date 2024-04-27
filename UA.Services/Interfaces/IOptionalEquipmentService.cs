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
    public interface IOptionalEquipmentService
    {
        Task<OptionalEquipmentDTO> GetById(int generationId);
        Task<int> Create(int generationId, CreateOptionalEquipmentDTO dto);
        Task Update(UpdateOptionalEquipmentDTO dto, int generationId);
        Task Delete(int generationId);
    }
}
