using AutoMapper;
using QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces;
using QuickLifeCoachingClinic.DTOs.ReferralDtoFolder;

namespace QuickLifeCoachingClinic.Services.ReferralServices
{
    public class ReferralService : IReferralService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReferralService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<IEnumerable<ReferralDto>> GetIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
