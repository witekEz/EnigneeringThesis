using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs.Update
{
    public class UpdateDrivetrainDTO
    {
        [MaxLength(40)]
        public string Type { get; set; } = null!;
    }
}
