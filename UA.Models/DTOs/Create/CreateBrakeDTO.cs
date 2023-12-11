using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs.Create
{
    public class CreateBrakeDTO
    {
        [Required]
        [MaxLength(25)]
        public string Type { get; set; } = null!;
    }
}
