﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs.Read.Rate;
using UA.Model.Entities;

namespace UA.Model.DTOs.Read
{
    public class GenerationDTO
    {
        public int Id { get; set; }
        public CategoryDTO Category { get; set; } = null!;
        public string Name { get; set; } = null!;
        public List<BodyDTO> Bodies { get; set; } = null!;
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public AvgRateGenerationDTO ?Rate { get; set; }
        public List<GenerationImageDTO>? Images { get; set; }
        public List<DrivetrainDTO> Drivetrains { get; set; } = null!;
        public List<EngineDTO> Engines { get; set; } = null!;
        public List<GearboxDTO> Gearboxes { get; set; } = null!;
        public DetailedInfoDTO? DetailedInfo { get; set; }
        public OptionalEquipmentDTO? OptionalEquipment { get; set; }
        public ModelDTO Model { get; set; } = null!;
    }
}
