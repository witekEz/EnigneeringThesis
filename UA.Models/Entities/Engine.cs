using UA.Model.Entities.Enums;

namespace UA.Model.Entities
{
    public class Engine
    {
        //Primary Key
        public int Id { get; set; }
        //Navigation Properties
        public string Version { get; set; } = null!;
        public double Capacity { get; set; }
        public int HorsePower { get; set; }
        public int Torque { get; set; }
        public TypeEnum Type { get; set; }
        public double FuelConsumptionCity { get; set; }
        public double FuelConsumptionSuburban { get; set; }
        public double Rate { get; set; }
        public virtual List<Generation>? Generations { get; set; }
    }
}