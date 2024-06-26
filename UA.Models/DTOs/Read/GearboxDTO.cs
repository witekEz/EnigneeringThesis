﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs.Read.Rate;
using UA.Model.Entities.Enums;

namespace UA.Model.DTOs.Read
{
    public class GearboxDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int NumberOfGears { get; set; }
        public string TypeOfGearbox { get; set; }
        public AvgRateGearboxDTO? Rate { get; set; }
    }
}
