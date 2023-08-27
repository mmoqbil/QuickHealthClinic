using Microsoft.AspNetCore.Mvc;

namespace QuickLifeCoachingClinic.Controllers
{
    [ApiController]
    [Route("/api/clinics")]
    public class ClinicController : Controller
    {
        private readonly IClinicService _clinicService;

        public ClinicController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
