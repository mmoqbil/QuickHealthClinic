using AutoMapper;
using QuickLifeCoachingClinic.DTOs.ReferralDtoFolder;

namespace QuickLifeCoachingClinic.Services.ReferralServices
{
    public class ReferralService : IReferralService
    {
        private readonly IMapper _mapper;
        public Task<IEnumerable<ReferralDto>> GetIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
