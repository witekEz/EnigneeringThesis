
using System.Diagnostics.CodeAnalysis;

namespace UA.Model.Entities
{
    public class BodyColour
    {
        //Primary Key
        public int Id { get; set; }
        //Navigation Properties
        public string Colour { get; set; } = null!;
        public string ?ColourCode { get; set; }
        public virtual List<DetailedInfo>? DeatiledInfos { get; set; }
    }
}