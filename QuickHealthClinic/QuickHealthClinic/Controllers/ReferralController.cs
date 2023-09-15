using Microsoft.AspNetCore.Mvc;
using QuickLifeCoachingClinic.DTOs.ReferralDtoFolder;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ReferralDto>>> GetReferralsByIdAsync([FromRoute] int id)
        {
            var referrals = await _referralService.GetIdAsync(id);
            return Ok(referrals);
        }
    }
}
