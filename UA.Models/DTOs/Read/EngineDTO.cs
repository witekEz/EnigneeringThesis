﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs.Read.Rate;
using UA.Model.Entities.Enums;

namespace UA.Model.DTOs.Read
{
    public class EngineDTO
    {
        public int Id { get; set; }
        public string Version { get; set; } = null!;
        public double Capacity { get; set; }
        public int HorsePower { get; set; }
        public int Torque { get; set; }
        public string Type { get; set; } = null!;
        public double FuelConsumptionCity { get; set; }
        public double FuelConsumptionSuburban { get; set; }
        public AvgRateEngineDTO? Rate { get; set; }
    }
}
