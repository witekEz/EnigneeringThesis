using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.Entities.Authentication;
using UA.Model.Entities;

namespace UA.Model.DTOs.Create.Rate
{
    public class CreateRateGenerationDTO
    {
        public double Value { get; set; }
        public int GenerationId { get; set; }
    }
}

