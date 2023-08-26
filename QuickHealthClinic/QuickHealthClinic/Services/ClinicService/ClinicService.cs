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
        public async Task<IEnumerable<ClinicDto>> GetClinicAsync()
        {
            var clinics = await _unitOfWork.ClinicRepository
                .GetAllAsync(includeProperties: "Address");

            var clinicsDto = _mapper.Map<List<ClinicDto>>(clinics);

            return clinicsDto;
        }
    }
}
