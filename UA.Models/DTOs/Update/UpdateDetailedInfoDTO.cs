namespace UA.Model.DTOs.Update
{
    public class UpdateDetailedInfoDTO
    {
        public List<UpdateSuspensionDTO>? Suspensions { get; set; }
        public DateTime ProductionStartDate { get; set; }
        public DateTime ProductionEndDate { get; set; }
        public List<UpdateBodyColourDTO>? BodyColours { get; set; }
        public List<UpdateBrakeDTO>? Brakes { get; set; }
    }
}