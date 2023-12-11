namespace UA.Model.DTOs.Create
{
    public class CreateDetailedInfoDTO
    {
        public List<CreateSuspensionDTO>? Suspensions { get; set; }
        public DateTime ProductionStartDate { get; set; }
        public DateTime ProductionEndDate { get; set; }
        public List<CreateBodyColourDTO>? BodyColours { get; set; }
        public List<CreateBrakeDTO>? Brakes { get; set; }
    }
}