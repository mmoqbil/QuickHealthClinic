namespace QuickLifeCoachingClinic.DTOs.VisitDtoFolder
{
    public class VisitStudentDto
    {
        public int Id { get; set; }
        public long StartDate { get; set; }
        public string Treatment { get; init; }
        public string Doctor { get; init; }
        public int DoctorId { get; init; }
        public int Duration { get; set; }
    }
}
