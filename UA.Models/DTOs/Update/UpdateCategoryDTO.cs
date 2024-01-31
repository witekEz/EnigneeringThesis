using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs.Update
{
    public class UpdateCategoryDTO
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;
    }
}
