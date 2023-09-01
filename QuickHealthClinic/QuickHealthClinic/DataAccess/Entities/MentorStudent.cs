namespace QuickLifeCoachingClinic.DataAccess.Entities
{
    public class MentorStudent
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int MentorId { get; set; }
        public Mentor Mentor { get; set; }
    }
}
