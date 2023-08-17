namespace QuickHealthClinic.DataAccess.Entities
{
    public class Doctor : Person
    {
        public string Specialist { get; set; }
        public string Description { get; set; }
        public string Education { get; set; }
        public string Services { get; set; }
    }
}
