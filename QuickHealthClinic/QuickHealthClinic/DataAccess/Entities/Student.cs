namespace QuickLifeCoachingClinic.DataAccess.Entities
{
    public class Student : Person
    {
        public string Pesel { get; set; }
        public virtual List<Clinic> Clinics { get; set; } = new();
        public virtual List<Mentor> Doctors { get; set; } = new();
        public virtual Role Role { get; set; } = Role.Student;
    }
}
