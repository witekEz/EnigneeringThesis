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
    public interface IBodyService
    {
        List<BodyDTO> GetAll(int generationId);
        BodyDTO GetById(int generationId, int id);
        int Create(int generationId,CreateBodyDTO dto);
        void Delete(int generationId, int id);
        void Update(int id,UpdateBodyDTO bodyTypeDTO);
    }
}
