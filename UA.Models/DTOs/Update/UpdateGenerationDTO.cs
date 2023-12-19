using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs.Update
{
    public class UpdateGenerationDTO
    {
        [MaxLength(20)]
        public string ?Category { get; set; }
        [MaxLength(20)]
        public string ?Name { get; set; }
        public List<UpdateBodyTypeDTO> ?BodyTypes { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public double Rate { get; set; }
        public List<UpdateDrivetrainDTO> ?Drivetrains { get; set; }
        public List<UpdateEngineDTO> ?Engines { get; set; }
        public List<UpdateGearboxDTO> ?Gearboxes { get; set; }
        public UpdateDetailedInfoDTO? DeatiledInfo { get; set; }
        public UpdateOptionalEquipmentDTO? OptionalEquipment { get; set; }
        public UpdateModelDTO ?Model { get; set; }
    }
}
