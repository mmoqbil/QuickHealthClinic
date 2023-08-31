using Microsoft.AspNetCore.Mvc;
using QuickLifeCoachingClinic.Services.VisitServices;

namespace QuickLifeCoachingClinic.Controllers
{
    [ApiController]
    [Route("/api/visits")]
    public class VisitController : ControllerBase
    {
        private readonly IVisitService _visitsService;

        public VisitController(IVisitService visitsService)
        {
            _visitsService = visitsService;
        }
    }
}
