namespace UA.Model.Entities
{
    public class OptionalEquipment
    {
        //Primary Key
        public int Id { get; set; }
        //Properties
        public bool RearAxleSteering { get; set; }
        public bool StandardTailPipes { get; set; }
        public bool Rooftop { get; set; }
        public bool ABS {  get; set; }
        public bool ESP { get; set; }
        public bool ASR { get; set; }
        //Navigation Properties
        public virtual Generation Generation { get; set; } = null!;
        //Foreign Key
        public int GenerationId { get; set; }
    }
}