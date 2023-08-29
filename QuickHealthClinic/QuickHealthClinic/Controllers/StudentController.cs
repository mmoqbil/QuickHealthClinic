using Microsoft.AspNetCore.Mvc;

namespace QuickLifeCoachingClinic.Controllers
{
    [ApiController]
    [Route("/api/students")]
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
