using AutoMapper;
using QuickHealthClinic.DataAccess.DbContexts;
using QuickHealthClinic.DataAccess.Repositories.Interfaces;
using QuickHealthClinic.DTOs.DoctorDtoFolder;
using QuickHealthClinic.Configurations.Exceptions;

namespace QuickHealthClinic.Services.DoctorServices
{
    public class DoctorService : IDoctorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly QuickHealthClinicContext _context;
        public DoctorService(IUnitOfWork unitOfWork, IMapper mapper, QuickHealthClinicContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsAsync() 
        {
            var doctors = await _unitOfWork.DoctorRepository.GetAllAsync(includeProperties: "Address");

            var doctorsDto = _mapper.Map<List<DoctorDto>>(doctors);

            return doctorsDto;
        }
        public async Task<IEnumerable<DoctorDto>> GetDoctorsBySpecializationAsync(string specialization)
        {
            var doctors = await _unitOfWork.DoctorRepository
                .GetAllAsync(d => d.Specialist == specialization, includeProperties: "Adress");

            var doctorsDto = _mapper.Map<List<DoctorDto>>(doctors);

            return doctorsDto;
        }

        public async Task<DoctorDto> GetDoctorByIdAsync(int id)
        {
            var doctor = await _unitOfWork.DoctorRepository
            .GetAsync(d => d.Id == id, "Address");

            if (doctor is null)
                throw new NotFoundApiException(nameof(DoctorDto), id.ToString());

            var doctorDto = _mapper.Map<DoctorDto>(doctor);

            return doctorDto;

        }
    }
}
