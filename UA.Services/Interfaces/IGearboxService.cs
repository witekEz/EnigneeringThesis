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
    public interface IGearboxService
    {
        List<GearboxDTO> GetAll();
        GearboxDTO GetById(int id);
        int Create(CreateGearboxDTO dto);
        void Update(int id, UpdateGearboxDTO dto);
        void Delete(int id);
    }
}
