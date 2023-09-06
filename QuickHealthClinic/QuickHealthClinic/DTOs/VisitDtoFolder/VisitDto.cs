namespace QuickLifeCoachingClinic.DTOs.VisitDtoFolder
{
    public class VisitDTO
    {
        public int Id { get; set; }
        public long StartDate { get; set; }
        public string Treatment { get; init; }
        public string Student { get; init; }
        public int StudentId { get; init; }
        public int Duration { get; set; }
        public bool? Confirmed { get; set; }
    }
}
