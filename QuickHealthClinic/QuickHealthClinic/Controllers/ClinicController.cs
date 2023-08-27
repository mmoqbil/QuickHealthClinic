using Microsoft.AspNetCore.Mvc;

namespace QuickLifeCoachingClinic.Controllers
{
    public class ClinicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
