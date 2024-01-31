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
        public string ?Name { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public double Rate { get; set; }
    }
}
