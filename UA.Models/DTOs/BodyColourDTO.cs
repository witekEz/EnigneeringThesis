using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs
{
    public class BodyColourDTO
    {
        public int Id { get; set; }
        public string Colour { get; set; } = null!;
        public string? ColourCode { get; set; }
    }
}
