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
    public interface IRateGearboxService
    {
        AvgRateGearboxDTO Get(int gearboxId);
        int Create(CreateRateGearboxDTO dto,int gearboxId, int userId);
        void Update(UpdateRateGearboxDTO dto, int gearboxId, int id, ClaimsPrincipal user);
        void Delete(int gearboxId, int id, ClaimsPrincipal user);
    }
}
