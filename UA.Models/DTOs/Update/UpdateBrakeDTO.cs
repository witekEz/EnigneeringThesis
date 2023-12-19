using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs.Update
{
    public class UpdateBrakeDTO
    {
        [MaxLength(25)]
        public string Type { get; set; } = null!;
    }
}
