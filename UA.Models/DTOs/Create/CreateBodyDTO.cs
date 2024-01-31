using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs.Create
{
    public class CreateBodyDTO
    {
        [Required]
        public CreateBodyTypeDTO BodyType { get; set; } = null!;
        public string? Segment { get; set; }
        public int NumberOfDoors { get; set; }
        public int NumberOfSeats { get; set; }
        public int TrunkCapacity { get; set; }
    }
}
