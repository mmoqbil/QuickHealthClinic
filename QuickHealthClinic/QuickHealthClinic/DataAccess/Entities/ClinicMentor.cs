namespace QuickLifeCoachingClinic.DataAccess.Entities
{
    public class ClinicMentor
    {
        public int MentorId { get; set; }
        public Mentor Mentor { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }
}
