using QuickHealthClinic.DTOs.DoctorDtoFolder;

namespace QuickHealthClinic.Services.DoctorServices
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDto>> GetDoctorsAsync();
        Task<IEnumerable<DoctorDto>> GetDoctorsBySpecializationAsync(string specialization);
        Task<DoctorDto> GetDoctorByIdAsync(int id);
    }
}
