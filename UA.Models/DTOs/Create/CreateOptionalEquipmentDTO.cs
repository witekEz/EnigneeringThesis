using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs.Create
{
    public class CreateOptionalEquipmentDTO
    {
        public bool RearAxleSteering { get; set; }
        public bool StandardTailPipes { get; set; }
        public bool Rooftop { get; set; }
        public bool ABS { get; set; }
        public bool ESP { get; set; }
        public bool ASR { get; set; }
    }
}
