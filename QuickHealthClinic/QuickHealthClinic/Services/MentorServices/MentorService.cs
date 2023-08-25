using AutoMapper;
using QuickLifeCoachingClinic.DataAccess.DbContexts;
using QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces;
using QuickLifeCoachingClinic.DTOs.DoctorDtoFolder;
using QuickLifeCoachingClinic.Configurations.Exceptions;
using Microsoft.AspNetCore.Identity;
using QuickLifeCoachingClinic.DataAccess.Entities;
using QuickLifeCoachingClinic.DTOs.AccountDtoFolder;

namespace QuickLifeCoachingClinic.Services.MentorServices
{
    public class MentorService : IMentorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly QuickLifeCoachingClinicContext _context;
        private readonly IPasswordHasher<Mentor> _passwordHasher;
        public MentorService(IUnitOfWork unitOfWork, IMapper mapper, QuickLifeCoachingClinicContext context, IPasswordHasher<Mentor> passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<MentorDto>> GetMentorsAsync()
        {
            var mentors = await _unitOfWork.MentorRepository.GetAllAsync(includeProperties: "Address");

            var mentorsDto = _mapper.Map<List<MentorDto>>(mentors);

            return mentorsDto;
        }
        public async Task<IEnumerable<MentorDto>> GetMentorsBySpecializationAsync(string specialization)
        {
            var mentors = await _unitOfWork.MentorRepository
                .GetAllAsync(d => d.Specialist == specialization, includeProperties: "Adress");

            var mentorsDto = _mapper.Map<List<MentorDto>>(mentors);

            return mentorsDto;
        }

        public async Task<MentorDto> GetMentorByIdAsync(int id)
        {
            var mentor = await _unitOfWork.MentorRepository
            .GetAsync(d => d.Id == id, "Address");

            if (mentor is null)
                throw new NotFoundApiException(nameof(MentorDto), id.ToString());

            var mentorDto = _mapper.Map<MentorDto>(mentor);

            return mentorDto;

        }

        public async Task<(int, CreateMentorDto)> CreateMentorAsync(CreateMentorDto dto)
        {
            var mentor = _mapper.Map<Mentor>(dto);
            var hashedPassword = _passwordHasher.HashPassword(mentor, dto.PasswordHash);
            mentor.PasswordHash = hashedPassword;

            await _unitOfWork.MentorRepository.AddAsync(mentor);
            await _unitOfWork.SaveAsync();

            return (mentor.Id, _mapper.Map<CreateMentorDto>(mentor));
        }
        public async Task UpdateMentorAsync(int id, UpdateMentorDto dto)
        {
            var mentor = await _unitOfWork.MentorRepository
                .GetAsync(id);

            if (mentor is null)
                throw new NotFoundApiException(nameof(MentorDto), id.ToString());

            _mapper.Map(dto, mentor);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteMentorAsync(int id)
        {
            var mentor = await _unitOfWork.MentorRepository
                .GetAsync(id);

            if (mentor is null)
                throw new NotFoundApiException(nameof(MentorDto), id.ToString());

            _unitOfWork.MentorRepository.Remove(mentor);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<string>?> GetCertificates(int id)
        {
            var mentor = await _unitOfWork.MentorRepository.GetAsync(d => d.Id == id, "Certificates");

            if (mentor is null)
                return null;

            return mentor.Certificates.Select(c => c.Filename);
        }

        public async Task<bool> AddCertificate(string filename, int id)
        {
            var mentor = await _unitOfWork.MentorRepository.GetAsync(id);

            if (mentor is null)
                return false;

            var certificate = new Certificate
            {
                Mentor = mentor,
                Filename = filename
            };

            mentor.Certificates.Add(certificate);
            await _unitOfWork.SaveAsync();

            return true;
        }
    }
}
