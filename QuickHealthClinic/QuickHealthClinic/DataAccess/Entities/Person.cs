namespace QuickHealthClinic.DataAccess.Entities
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public DateTime Created { get; }
        public string AvatarUri { get; set; } = string.Empty;
    }
}
