using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs
{
    public class BodyTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Segment { get; set; }
        public int NumberOfDoors { get; set; }
        public int NumberOfSeats { get; set; }
        public int TrunkCapacity { get; set; }
    }
}
