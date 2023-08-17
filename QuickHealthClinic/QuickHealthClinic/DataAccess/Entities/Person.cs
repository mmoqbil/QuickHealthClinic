namespace QuickHealthClinic.DataAccess.Entities
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; }
        public string AvatarUri { get; set; }
    }
}
