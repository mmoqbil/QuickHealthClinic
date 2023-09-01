
namespace QuickLifeCoachingClinic.DataAccess.Entities
{
    public class Mentor : Person
    {
        public string Specialist { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Education { get; set; } = string.Empty;
        public string Services { get; set; } = string.Empty;
        public virtual List<Clinic> Clinics { get; set; } = new();
        public virtual List<Student> Students { get; set; } = new();
        public virtual Role Role { get; set; } = Role.Mentor;
        public List<Certificate> Certificates { get; set; } = new();
    }
}
