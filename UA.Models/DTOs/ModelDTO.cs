using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.Entities;

namespace UA.Model.DTOs
{
    public class ModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<GenerationDTO>? Generations { get; set; }
    }
}
