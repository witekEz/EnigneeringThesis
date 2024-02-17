using UA.Model.Entities.Enums;
using UA.Model.Entities.Rate;

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
        //Navigation Properties
        public virtual List<RateGearbox>? Rates { get; set; }
        public virtual List<Generation>? Generations { get; set; }
        public virtual AvgRateGearbox? AvgRateGearbox { get; set; }

    }
}