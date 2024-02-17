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
        List<SuspensionDTO> GetAll();
        SuspensionDTO GetById(int id);
        int Create(CreateSuspensionDTO dto);
        void Update(int id, UpdateSuspensionDTO dto);
        void Delete(int id);
    }
}
