using QuickLifeCoachingClinic.DTOs.AccountDtoFolder;
using QuickLifeCoachingClinic.DTOs.DoctorDtoFolder;

namespace QuickLifeCoachingClinic.Services.MentorServices
{
    public interface IMentorService
    {
        Task<IEnumerable<MentorDto>> GetMentorsAsync();
        Task<IEnumerable<MentorDto>> GetMentorsBySpecializationAsync(string specialization);
        Task<MentorDto> GetMentorByIdAsync(int id);
        Task<(int, CreateMentorDto)> CreateMentorAsync(CreateMentorDto dto);
        Task UpdateMentorAsync(int id, UpdateMentorDto dto);
        Task DeleteMentorAsync(int id);
        Task<IEnumerable<string>?> GetCertificates(int id);
        Task<bool> AddCertificate(string filename, int id);
    }
}
