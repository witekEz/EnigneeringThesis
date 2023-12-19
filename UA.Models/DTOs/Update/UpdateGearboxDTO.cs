using System.ComponentModel.DataAnnotations;
using UA.Model.Entities.Enums;

namespace UA.Model.DTOs.Update
{
    public class UpdateGearboxDTO
    {
        [MaxLength(20)]
        public string ?Name { get; set; }
        public int NumberOfGears { get; set; }
        public TypeOfGearboxEnum TypeOfGearbox { get; set; }
        public double Rate { get; set; }
    }
}