namespace QuickLifeCoachingClinic.DataAccess.Entities
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Mentor> Mentors { get; set; } = new();
        public virtual List<Student> Students { get; set; } = new();
    }
}
