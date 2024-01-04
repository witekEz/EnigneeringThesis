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
    public interface IBrakeService
    {
        List<BrakeDTO> GetAll();
        BrakeDTO GetById(int id);
        int Create(CreateBrakeDTO dto);
        void Update(int id, UpdateBrakeDTO dto);
        void Delete(int id);
    }
}
