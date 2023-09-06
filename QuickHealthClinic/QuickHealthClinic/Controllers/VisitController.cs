using Microsoft.AspNetCore.Mvc;
using QuickLifeCoachingClinic.DTOs.VisitDtoFolder;
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

        [HttpGet("calendar/{mentorId}")]
        public async Task<IEnumerable<VisitCalendarDto>> GetVisitsForMonth([FromRoute] int mentorId, [FromQuery] int year,
            int month)
        {
            var visits = await _visitsService.GetVisitsForMonth(mentorId, new DateOnly(year, month, 1));
            return visits;
        }

        [HttpPost("{visitId}/accept")]
        public async Task<bool> AcceptVisit(int visitId)
        {
            return await _visitsService.AcceptVisit(visitId);
        }
    }
}
