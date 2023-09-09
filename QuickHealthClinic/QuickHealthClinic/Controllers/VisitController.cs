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

        [HttpGet("{mentorId}")]
        public async Task<IEnumerable<VisitDTO>> GetAllVisitsForMentor([FromRoute] int mentorId)
        {
            var visits = _visitsService.GetVisitsByMentorIdAsync(mentorId);
            return await visits;
        }

        [HttpGet("user/{studentId}")]
        public async Task<IEnumerable<VisitStudentDto>> GetAllVisitsForUser([FromRoute] int studentId)
        {
            var visits = _visitsService.GetVisitsByStudentIdAsync(studentId);
            return await visits;
        }

        [HttpPost("{visitId}/accept")]
        public async Task<bool> AcceptVisit(int visitId)
        {
            return await _visitsService.AcceptVisit(visitId);
        }

        [HttpPost("{visitId}/decline")]
        public async Task<bool> DeclineVisit(int visitId)
        {
            return await _visitsService.DeclineVisit(visitId);
        }

        [HttpPost]
        public async Task<IActionResult> AddVisit([FromBody] CreateVisitDto visitDto)
        {
            var (visitId, visit) = await _visitsService.CreateVisitAsync(visitDto);
            return Created($"/api/visits/{visit.MentorId}", visit);
        }

        [HttpPut("{id}")]
        public async Task<bool> EditVisit([FromRoute] int id, [FromBody] PutVisitDto visitDto)
        {
            var visit = await _visitsService.EditVisitAsync(id, visitDto);
            return visit != null;
        }
    }
}
