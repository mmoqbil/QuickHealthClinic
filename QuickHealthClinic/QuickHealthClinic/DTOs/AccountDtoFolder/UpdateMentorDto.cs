using System.ComponentModel.DataAnnotations;

namespace QuickLifeCoachingClinic.DTOs.AccountDtoFolder
{
    public class UpdateMentorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Phone] public string PhoneNumber { get; set; }

        [EmailAddress] public string Email { get; set; }
    }
}
