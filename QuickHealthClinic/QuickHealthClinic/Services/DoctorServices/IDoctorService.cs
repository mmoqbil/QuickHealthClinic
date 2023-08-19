using QuickHealthClinic.DTOs.DoctorDtoFolder;

namespace QuickHealthClinic.Services.DoctorServices
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDto>> GetDoctorsAsync();
    }
}
