using AutoMapper;
using QuickLifeCoachingClinic.Configurations.Exceptions;
using QuickLifeCoachingClinic.DataAccess.Entities;
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
        public async Task<IEnumerable<ClinicDto>> GetAsync()
        {
            var clinics = await _unitOfWork.ClinicRepository
                .GetAllAsync(includeProperties: "Address");

            var clinicsDto = _mapper.Map<List<ClinicDto>>(clinics);

            return clinicsDto;
        }

        public async Task<ClinicDto> GetByIdAsync(int id)
        {
            var clinic = await _unitOfWork.ClinicRepository
                .GetAsync(c => c.Id == id, "Address");

            if (clinic is null)
                throw new NotFoundApiException(nameof(ClinicDto), id.ToString());

            var clinicDto = _mapper.Map<ClinicDto>(clinic);

            return clinicDto;
        }

        public async Task<(int, CreateClinicDto)> CreateAsync(CreateClinicDto dto)
        {
            var clinic = _mapper.Map<Clinic>(dto);

            await _unitOfWork.ClinicRepository.AddAsync(clinic);
            await _unitOfWork.SaveAsync();

            return (clinic.Id, _mapper.Map<CreateClinicDto>(clinic));
        }

        public async Task UpdateAsync(int id, UpdateClinicDto dto)
        {
            var clinic = await _unitOfWork.ClinicRepository
                .GetAsync(id);

            if (clinic is null)
                throw new NotFoundApiException(nameof(ClinicDto), id.ToString());

            _mapper.Map(dto, clinic);
            await _unitOfWork.SaveAsync();
        }
    }
}
