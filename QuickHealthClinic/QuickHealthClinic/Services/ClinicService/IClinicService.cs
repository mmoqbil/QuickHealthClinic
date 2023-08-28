using QuickLifeCoachingClinic.DTOs.ClinicDto;

namespace QuickLifeCoachingClinic.Services.ClinicService
{
    public interface IClinicService
    {
        Task<IEnumerable<ClinicDto>> GetClinicsAsync();
        Task<ClinicDto> GetClinicByIdAsync(int id);
        Task<(int, CreateClinicDto)> CreateClinicAsync(CreateClinicDto dto);
    }
}
