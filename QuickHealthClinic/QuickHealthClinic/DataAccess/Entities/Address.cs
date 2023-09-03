namespace QuickLifeCoachingClinic.DataAccess.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public virtual Mentor Mentor { get; set; }
        public virtual Clinic Clinic { get; set; }
        public virtual Student Student { get; set; }
    }
}
