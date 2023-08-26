using AutoMapper;
using QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces;
using QuickLifeCoachingClinic.DTOs.ClinicDto;

namespace QuickLifeCoachingClinic.Services.ClinicService
{
    public class ClinicService : IClinicService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ClinicService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<IEnumerable<ClinicDto>> GetClinicAsync()
        {
            throw new NotImplementedException();
        }
    }
}
