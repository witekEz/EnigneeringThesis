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
    public interface IDetailedInfoService
    {
        DetailedInfoDTO GetById(int generationId);
        int Create(int generationId, CreateDetailedInfoDTO dto);
        void Update(UpdateDetailedInfoDTO dto, int generationId);
        void Delete(int generationId);
    }
}
