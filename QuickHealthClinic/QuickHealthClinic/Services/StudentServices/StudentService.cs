using AutoMapper;
using QuickLifeCoachingClinic.DataAccess.DbContexts;
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
            throw new NotImplementedException();
        }
    }
}
