using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs.Create
{
    public class CreateGenerationImageDTO
    {
        public Guid ImageGUID { get; set; }
        public int GenerationId { get; set; }
    }
}
