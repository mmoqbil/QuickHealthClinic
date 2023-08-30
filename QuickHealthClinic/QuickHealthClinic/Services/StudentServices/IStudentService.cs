using QuickLifeCoachingClinic.DTOs.AccountDtoFolder;
using QuickLifeCoachingClinic.DTOs.StudentDtoFolder;

namespace QuickLifeCoachingClinic.Services.StudentServices
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetStudentsAsync();
        Task<StudentDto> GetIdAsync(int id);
        Task<(int, CreateStudentDto)> CreateAsync(CreateStudentDto dto);
        Task UpdateAsync(int id, UpdateStudentDto dto);
    }
}
