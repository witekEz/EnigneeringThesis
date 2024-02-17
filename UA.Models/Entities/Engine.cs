using UA.Model.Entities.Enums;
using UA.Model.Entities.Rate;

namespace UA.Model.Entities
{
    public class Engine
    {
        //Primary Key
        public int Id { get; set; }
        //Properties
        public string Version { get; set; } = null!;
        public double Capacity { get; set; }
        public int HorsePower { get; set; }
        public int Torque { get; set; }
        public TypeEnum Type { get; set; }
        public double FuelConsumptionCity { get; set; }
        public double FuelConsumptionSuburban { get; set; }
        //Navigation Properties
        public virtual List<RateEngine>? Rates { get; set; }
        public virtual List<Generation>? Generations { get; set; }
        public virtual AvgRateEngine? AvgRateEngine { get; set; }
    }
}