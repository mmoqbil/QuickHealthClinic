using Microsoft.AspNetCore.Mvc;

namespace QuickHealthClinic.Controllers
{
    [ApiController]
    [Route("/api/account")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
