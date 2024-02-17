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
        List<EngineDTO> GetAll();
        EngineDTO GetById(int id);
        int Create(CreateEngineDTO dto);
        void Update(int id,UpdateEngineDTO dto);
        void Delete(int id);
    }
}
