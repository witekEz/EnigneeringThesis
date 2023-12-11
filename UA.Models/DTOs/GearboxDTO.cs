using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.Entities.Enums;

namespace UA.Model.DTOs
{
    public class GearboxDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int NumberOfGears { get; set; }
        public TypeOfGearboxEnum TypeOfGearbox { get; set; }
        public double Rate { get; set; }
    }
}
