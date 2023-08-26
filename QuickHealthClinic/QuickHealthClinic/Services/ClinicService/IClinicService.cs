using QuickLifeCoachingClinic.DTOs.ClinicDto;

namespace QuickLifeCoachingClinic.Services.ClinicService
{
    public interface IClinicService
    {
        Task<IEnumerable<ClinicDto>> GetClinicAsync();
    }
}
