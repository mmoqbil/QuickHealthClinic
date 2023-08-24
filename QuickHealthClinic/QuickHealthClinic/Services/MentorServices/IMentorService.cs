using QuickHealthClinic.DTOs.AccountDtoFolder;
using QuickHealthClinic.DTOs.DoctorDtoFolder;

namespace QuickHealthClinic.Services.MentorServices
{
    public interface IMentorService
    {
        Task<IEnumerable<MentorDto>> GetMentorsAsync();
        Task<IEnumerable<MentorDto>> GetMentorsBySpecializationAsync(string specialization);
        Task<MentorDto> GetMentorByIdAsync(int id);
        Task<(int, CreateMentorDto)> CreateMentorAsync(CreateMentorDto dto);
    }
}
