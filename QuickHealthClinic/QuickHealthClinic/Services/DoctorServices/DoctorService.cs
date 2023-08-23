using AutoMapper;
using QuickHealthClinic.DataAccess.DbContexts;
using QuickHealthClinic.DataAccess.Repositories.Interfaces;
using QuickHealthClinic.DTOs.DoctorDtoFolder;
using QuickHealthClinic.Configurations.Exceptions;
using Microsoft.AspNetCore.Identity;
using QuickHealthClinic.DataAccess.Entities;
using QuickHealthClinic.DTOs.AccountDtoFolder;

namespace QuickHealthClinic.Services.DoctorServices
{
    public class DoctorService : IDoctorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly QuickHealthClinicContext _context;
        private readonly IPasswordHasher<Doctor> _passwordHasher;
        public DoctorService(IUnitOfWork unitOfWork, IMapper mapper, QuickHealthClinicContext context, IPasswordHasher<Doctor> passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
            _passwordHasher = passwordHasher;
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

        public async Task<(int, CreateDoctorDto)> CreateDoctorAsync(CreateDoctorDto dto)
        {
            var doctor = _mapper.Map<Doctor>(dto);
            var hashedPassword = _passwordHasher.HashPassword(doctor, dto.PasswordHash);
            doctor.PasswordHash = hashedPassword;

            await _unitOfWork.DoctorRepository.AddAsync(doctor);
            await _unitOfWork.SaveAsync();

            return (doctor.Id, _mapper.Map<CreateDoctorDto>(doctor));
        }
    }
}
