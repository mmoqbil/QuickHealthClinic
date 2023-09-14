using Microsoft.AspNetCore.Mvc;

namespace QuickLifeCoachingClinic.Controllers
{
    public class ReferralController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
