using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs.Create
{
    public class CreateBodyColourDTO
    {
        [Required]
        [MaxLength(50)]
        public string Colour { get; set; } = null!;
        [MaxLength(10)]
        public string? ColourCode { get; set; }
    }
}
