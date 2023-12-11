using System.ComponentModel.DataAnnotations.Schema;

namespace UA.Model.Entities
{
    public class BodyType
    {
        //Primary Key
        public int Id { get; set; }
        //Navigation Properties
        public string Name { get; set; } = null!;
        public string? Segment { get; set; }
        public int NumberOfDoors { get; set; }
        public int NumberOfSeats { get; set; }
        public int TrunkCapacity { get; set; }
        public virtual List<Generation>? Generations { get; set; }

    }
}