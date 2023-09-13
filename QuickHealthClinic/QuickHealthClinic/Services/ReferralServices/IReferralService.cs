using QuickLifeCoachingClinic.DTOs.ReferralDtoFolder;

namespace QuickLifeCoachingClinic.Services.ReferralServices
{
    public interface IReferralService
    {
        Task<IEnumerable<ReferralDto>> GetIdAsync(int id);
    }
}
