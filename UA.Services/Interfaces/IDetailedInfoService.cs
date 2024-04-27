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
    public interface IDetailedInfoService
    {
        Task<DetailedInfoDTO> GetById(int generationId);
        Task<int> Create(int generationId, CreateDetailedInfoDTO dto);
        Task Update(UpdateDetailedInfoDTO dto, int generationId);
        Task Delete(int generationId);
    }
}
