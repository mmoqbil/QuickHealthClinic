using QuickLifeCoachingClinic.DTOs.ClinicDto;

namespace QuickLifeCoachingClinic.Services.ClinicService
{
    public interface IClinicService
    {
        Task<IEnumerable<ClinicDto>> GetAsync();
        Task<ClinicDto> GetByIdAsync(int id);
        Task<IEnumerable<ClinicMentorDto>> GetMentorsAsync(int id);
        Task<(int, CreateClinicDto)> CreateAsync(CreateClinicDto dto);
        Task UpdateAsync(int id, UpdateClinicDto dto);
        Task DeleteAsync(int id);
    }
}
