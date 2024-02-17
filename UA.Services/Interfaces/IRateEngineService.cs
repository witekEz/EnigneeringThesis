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
        AvgRateEngineDTO Get(int engineId);
        int Create(CreateRateEngineDTO dto, int engineId, int userId);
        void Update(UpdateRateEngineDTO dto, int engineId, int id, ClaimsPrincipal user);
        void Delete(int engineId, int id, ClaimsPrincipal user);
    }
}
