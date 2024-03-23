namespace UA.Model.DTOs.Create
{
    public class CreateDetailedInfoDTO
    {
        public DateTime ProductionStartDate { get; set; }
        public DateTime ProductionEndDate { get; set; }
        public List<int> ?BodyColours { get; set; }
        public List<int>? Brakes { get; set; }
        public List<int> ?Suspensions { get; set; }
    }
}