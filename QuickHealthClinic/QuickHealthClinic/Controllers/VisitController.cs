using Microsoft.AspNetCore.Mvc;

namespace QuickLifeCoachingClinic.Controllers
{
    public class VisitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
