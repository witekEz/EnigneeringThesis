using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs.Create
{
    public class CreateGenerationDTO
    {
        [Required]
        [MaxLength(20)]
        public string Category { get; set; } = null!;
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = null!;
        [Required]
        public List<CreateBodyTypeDTO> BodyTypes { get; set; } = null!;
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public double Rate { get; set; }
        [Required]
        public List<CreateDrivetrainDTO> Drivetrains { get; set; } = null!;
        [Required]
        public List<CreateEngineDTO> Engines { get; set; } = null!;
        [Required]
        public List<CreateGearboxDTO> Gearboxes { get; set; } = null!;
        public CreateDetailedInfoDTO? DeatiledInfo { get; set; }
        public CreateOptionalEquipmentDTO? OptionalEquipment { get; set; }
        [Required]
        public CreateModelDTO Model { get; set; } = null!;
    }
}
