using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs.Create.Rate;
using UA.Model.DTOs.Read.Rate;
using UA.Model.DTOs.Update.Rate;

namespace UA.Services.Interfaces
{
    public interface IRateEngineService
    {
        Task<AvgRateEngineDTO> Get(int engineId);
        Task<int> Create(CreateRateEngineDTO dto, int engineId, int userId);
        Task Update(UpdateRateEngineDTO dto, int engineId, int id, ClaimsPrincipal user);
        Task Delete(int engineId, int id, ClaimsPrincipal user);
    }
}
