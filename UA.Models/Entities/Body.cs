using System.ComponentModel.DataAnnotations.Schema;

namespace UA.Model.Entities
{
    public class Body
    {
        //Primary Key
        public int Id { get; set; }
        //Properties
        public string? Segment { get; set; }
        public int NumberOfDoors { get; set; }
        public int NumberOfSeats { get; set; }
        public int TrunkCapacity { get; set; }
        //Navigation Properties
        public virtual Generation Generation { get; set; } = null!;
        public virtual BodyType ?BodyType { get; set; }
        //Foreign Key
        public int GenerationId { get; set; }
        public int BodyTypeId { get; set; }

    }
}