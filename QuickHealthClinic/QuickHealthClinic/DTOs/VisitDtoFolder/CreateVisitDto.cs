namespace QuickLifeCoachingClinic.DTOs.VisitDtoFolder
{
    public class CreateVisitDto
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public int MentorId { get; set; }
        public DateTime VisitDate { get; set; }
        public int Duration { get; set; }
    }
}
