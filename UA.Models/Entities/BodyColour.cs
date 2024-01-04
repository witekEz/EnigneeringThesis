
using System.Diagnostics.CodeAnalysis;

namespace UA.Model.Entities
{
    public class BodyColour
    {
        //Primary Key
        public int Id { get; set; }
        //Properties
        public string Colour { get; set; } = null!;
        public string ?ColourCode { get; set; }
        //Navigation properties
        public virtual List<DetailedInfo>? DetailedInfos { get; set; }
    }
}