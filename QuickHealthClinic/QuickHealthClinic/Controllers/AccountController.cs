using Microsoft.AspNetCore.Mvc;
using QuickHealthClinic.Services.DoctorServices;

namespace QuickHealthClinic.Controllers
{
    [ApiController]
    [Route("/api/account")]
    public class AccountController : Controller
    {
        private readonly IDoctorService _doctorService;
        public AccountController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
