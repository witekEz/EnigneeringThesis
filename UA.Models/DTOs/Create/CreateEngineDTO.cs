using System.ComponentModel.DataAnnotations;
using UA.Model.Entities.Enums;

namespace UA.Model.DTOs.Create
{
    public class CreateEngineDTO
    {
        [Required]
        [MaxLength(40)]
        public string Version { get; set; } = null!;
        public double Capacity { get; set; }
        public int HorsePower { get; set; }
        public int Torque { get; set; }
        public TypeEnum Type { get; set; }
        public double FuelConsumptionCity { get; set; }
        public double FuelConsumptionSuburban { get; set; }
    }
}