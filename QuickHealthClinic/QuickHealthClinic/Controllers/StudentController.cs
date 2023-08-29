using Microsoft.AspNetCore.Mvc;
using QuickLifeCoachingClinic.DTOs.StudentDtoFolder;
using QuickLifeCoachingClinic.Services.StudentServices;

namespace QuickLifeCoachingClinic.Controllers
{
    [ApiController]
    [Route("/api/students")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAllStudentsAsync()
        {
            var students = await _studentService.GetStudentsAsync();
            return Ok(students);
        }
    }
}
