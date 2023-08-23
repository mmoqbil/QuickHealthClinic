namespace QuickHealthClinic.DataAccess.Entities
{
    public class Doctor : Person
    {
        public string Specialist { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Education { get; set; } = string.Empty;
        public string Services { get; set; } = string.Empty;
        public virtual Role Role { get; set; } = Role.Doctor;
    }
}
