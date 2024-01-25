using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs
{
    public class GenerationImageDTO
    {
        public int Id { get; set; }
        public byte[] Image { get; set; } = null!;

    }
}
