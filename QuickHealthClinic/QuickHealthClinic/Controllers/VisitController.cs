using Microsoft.AspNetCore.Mvc;

namespace QuickLifeCoachingClinic.Controllers
{
    [ApiController]
    [Route("/api/visits")]
    public class VisitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
