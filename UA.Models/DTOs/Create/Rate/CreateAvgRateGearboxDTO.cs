using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.Entities;

namespace UA.Model.DTOs.Create.Rate
{
    public class CreateAvgRateGearboxDTO
    {
        public double Value { get; set; }
        public int NumberOfRates { get; set; }
        public int GearboxId { get; set; }
    }
}
