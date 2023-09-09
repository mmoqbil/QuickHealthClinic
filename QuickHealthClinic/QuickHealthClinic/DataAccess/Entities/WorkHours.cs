namespace QuickLifeCoachingClinic.DataAccess.Entities
{
    public class WorkHours
    {
        public int Id { get; set; }
        public int MentorId { get; set; }
        public virtual Mentor? Mentor { get; set; }
        public string Day { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
    }
}
