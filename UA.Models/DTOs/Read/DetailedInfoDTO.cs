using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.Entities;

namespace UA.Model.DTOs.Read
{
    public class DetailedInfoDTO
    {
        public int Id { get; set; }
        public List<SuspensionDTO>? Suspensions { get; set; }
        public DateTime ProductionStartDate { get; set; }
        public DateTime ProductionEndDate { get; set; }
        public List<BodyColourDTO>? BodyColours { get; set; }
        public List<BrakeDTO>? Brakes { get; set; }
    }
}
