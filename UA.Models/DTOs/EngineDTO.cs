using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.Entities.Enums;

namespace UA.Model.DTOs
{
    public class EngineDTO
    {
        public int Id { get; set; }
        public string Version { get; set; } = null!;
        public double Capacity { get; set; }
        public int HorsePower { get; set; }
        public int Torque { get; set; }
        public TypeEnum Type { get; set; }
        public double FuelConsumptionCity { get; set; }
        public double FuelConsumptionSuburban { get; set; }
        public double Rate { get; set; }
    }
}
