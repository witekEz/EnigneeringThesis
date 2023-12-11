using UA.Model.Entities.Enums;

namespace UA.Model.Entities
{
    public class Gearbox
    {
        //Primary Key
        public int Id { get; set; }

        //Properties
        public string Name { get; set; } = null!;
        public int NumberOfGears { get; set; }
        public TypeOfGearboxEnum TypeOfGearbox { get; set; }
        public double Rate { get; set; }
        public virtual List<Generation> ?Generations { get; set; }

        
    }
}