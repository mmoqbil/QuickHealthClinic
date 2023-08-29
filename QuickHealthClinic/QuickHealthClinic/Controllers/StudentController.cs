using Microsoft.AspNetCore.Mvc;
using QuickLifeCoachingClinic.Services.StudentServices;

namespace QuickLifeCoachingClinic.Controllers
{
    [ApiController]
    [Route("/api/students")]
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;
        public IActionResult Index()
        {
            return View();
        }
    }
}
