using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;
using UA.Model.DTOs;

namespace UA.Services.Interfaces
{
    public interface IOptionalEquipmentService
    {
        OptionalEquipmentDTO GetById(int generationId);
        int Create(int generationId, CreateOptionalEquipmentDTO dto);
        void Update(UpdateOptionalEquipmentDTO dto, int generationId);
        void Delete(int generationId);
    }
}
