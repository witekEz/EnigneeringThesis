using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs.Read.Rate
{
    public class AvgRateGearboxDTO
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public int NumberOfRates { get; set; }
    }
}
