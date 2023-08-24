using QuickHealthClinic.DTOs.AccountDtoFolder;
using QuickHealthClinic.DTOs.DoctorDtoFolder;

namespace QuickHealthClinic.Services.DoctorServices
{
    public interface IMentorService
    {
        Task<IEnumerable<MentorDto>> GetMentorsAsync();
        Task<IEnumerable<MentorDto>> GetMentorsBySpecializationAsync(string specialization);
        Task<MentorDto> GetDoctorByIdAsync(int id);
        Task<(int, CreateMentorDto)> CreateDoctorAsync(CreateMentorDto dto);
    }
}
