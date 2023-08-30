using AutoMapper;
using QuickLifeCoachingClinic.Configurations.Exceptions;
using QuickLifeCoachingClinic.DataAccess.DbContexts;
using QuickLifeCoachingClinic.DataAccess.Entities;
using QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces;
using QuickLifeCoachingClinic.DTOs.StudentDtoFolder;

namespace QuickLifeCoachingClinic.Services.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly QuickLifeCoachingClinicContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(QuickLifeCoachingClinicContext context, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsAsync()
        {
            var studients = await _unitOfWork.StudentRepository
            .GetAllAsync(includeProperties: "Address");

            var studentsDto = _mapper.Map<List<StudentDto>>(studients);

            return studentsDto;
        }

        public async Task<StudentDto> GetIdAsync(int id)
        {
            var student = await _unitOfWork.StudentRepository
                .GetAsync(p => p.Id == id, "Address");

            if (student is null)
                throw new NotFoundApiException(nameof(StudentDto), id.ToString());

            var studentDto = _mapper.Map<StudentDto>(student);

            return studentDto;
        }

        public async Task<(int, CreateStudentDto)> CreateAsync(CreateStudentDto dto)
        {
            var student = _mapper.Map<Student>(dto);

            await _unitOfWork.StudentRepository.AddAsync(student);
            await _unitOfWork.SaveAsync();

            return (student.Id, _mapper.Map<CreateStudentDto>(student));
        }
    }
}
