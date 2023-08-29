using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
