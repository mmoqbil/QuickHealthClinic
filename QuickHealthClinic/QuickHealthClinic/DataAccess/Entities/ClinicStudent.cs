namespace QuickLifeCoachingClinic.DataAccess.Entities
{
    public class ClinicStudent
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }
}
