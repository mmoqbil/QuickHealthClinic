namespace QuickLifeCoachingClinic.DataAccess.Entities
{
    public class Visit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int MentorId { get; set; }
        public virtual Mentor Mentor { get; set; }
        public DateTime VisitDate { get; set; }
        public int Duration { get; set; }
        public bool? Confirmed { get; set; } = null;
    }
}
