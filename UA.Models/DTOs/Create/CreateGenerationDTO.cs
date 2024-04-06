using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs.Create.Rate;

namespace UA.Model.DTOs.Create
{
    public class CreateGenerationDTO
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = null!;
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public CreateBodyDTO Body { get; set; } = null!;
        [Required]
        public List<int> Drivetrains { get; set; } = null!;
        [Required]
        public List<int> Engines { get; set; } = null!;
        [Required]
        public List<int> Gearboxes { get; set; } = null!;
        public CreateDetailedInfoDTO? DetailedInfo { get; set; }
        public CreateOptionalEquipmentDTO? OptionalEquipment { get; set; }
        
    }
}
