using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UA.Model.Entities.Enums;

namespace UA.Model.DTOs.Create
{
    public class CreateGearboxDTO
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = null!;
        public int NumberOfGears { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TypeOfGearboxEnum TypeOfGearbox { get; set; }
    }
}