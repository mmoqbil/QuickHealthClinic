using AutoMapper;
using QuickHealthClinic.DataAccess.DbContexts;
using QuickHealthClinic.DataAccess.Repositories.Interfaces;
using QuickHealthClinic.DTOs.DoctorDtoFolder;
using QuickHealthClinic.Configurations.Exceptions;
using Microsoft.AspNetCore.Identity;
using QuickHealthClinic.DataAccess.Entities;
using QuickHealthClinic.DTOs.AccountDtoFolder;

namespace QuickHealthClinic.Services.MentorServices
{
    public class MentorService : IMentorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly QuickHealthClinicContext _context;
        private readonly IPasswordHasher<Mentor> _passwordHasher;
        public MentorService(IUnitOfWork unitOfWork, IMapper mapper, QuickHealthClinicContext context, IPasswordHasher<Mentor> passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<MentorDto>> GetMentorsAsync()
        {
            var doctors = await _unitOfWork.MentorRepository.GetAllAsync(includeProperties: "Address");

            var doctorsDto = _mapper.Map<List<MentorDto>>(doctors);

            return doctorsDto;
        }
        public async Task<IEnumerable<MentorDto>> GetMentorsBySpecializationAsync(string specialization)
        {
            var doctors = await _unitOfWork.MentorRepository
                .GetAllAsync(d => d.Specialist == specialization, includeProperties: "Adress");

            var doctorsDto = _mapper.Map<List<MentorDto>>(doctors);

            return doctorsDto;
        }

        public async Task<MentorDto> GetMentorByIdAsync(int id)
        {
            var doctor = await _unitOfWork.MentorRepository
            .GetAsync(d => d.Id == id, "Address");

            if (doctor is null)
                throw new NotFoundApiException(nameof(MentorDto), id.ToString());

            var doctorDto = _mapper.Map<MentorDto>(doctor);

            return doctorDto;

        }

        public async Task<(int, CreateMentorDto)> CreateMentorAsync(CreateMentorDto dto)
        {
            var doctor = _mapper.Map<Mentor>(dto);
            var hashedPassword = _passwordHasher.HashPassword(doctor, dto.PasswordHash);
            doctor.PasswordHash = hashedPassword;

            await _unitOfWork.MentorRepository.AddAsync(doctor);
            await _unitOfWork.SaveAsync();

            return (doctor.Id, _mapper.Map<CreateMentorDto>(doctor));
        }
    }
}
