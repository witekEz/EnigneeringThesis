using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;

namespace UA.Services.Interfaces
{
    public interface IBodyTypeService
    {
        List<BodyTypeDTO> GetAll(int generationId);
        BodyTypeDTO GetById(int generationId, int id);
        int Create(int generationId,CreateBodyTypeDTO dto);
        void Delete(int generationId, int id);
        void Update(int id,UpdateBodyTypeDTO bodyTypeDTO);
    }
}
