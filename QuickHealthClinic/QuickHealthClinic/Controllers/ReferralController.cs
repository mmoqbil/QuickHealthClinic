using Microsoft.AspNetCore.Mvc;
using QuickLifeCoachingClinic.Services.ReferralServices;

namespace QuickLifeCoachingClinic.Controllers
{
    [ApiController]
    [Route("/api/referrals")]
    public class ReferralController : ControllerBase
    {
        private readonly IReferralService _referralService;

        public ReferralController(IReferralService referralService)
        {
            _referralService = referralService;
        }
    }
}
