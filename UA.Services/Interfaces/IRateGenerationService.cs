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
    public interface IRateGenerationService
    {
        AvgRateGenerationDTO Get(int generationId);
        int Create(CreateRateGenerationDTO dto, int generationId, int userId);
        void Update(UpdateRateGenerationDTO dto, int generationId, int id, ClaimsPrincipal user);
        void Delete(int generationId, int id, ClaimsPrincipal user);
    }
}
