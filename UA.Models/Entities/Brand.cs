
using System.Diagnostics.CodeAnalysis;

namespace UA.Model.Entities
{
    public class Brand
    {
        //Primary Key
        public int Id { get; set; }
        //Navigation Properties
        public string Name { get; set; } = null!;
        public virtual List<Model>? Models { get; set; }
    }
}