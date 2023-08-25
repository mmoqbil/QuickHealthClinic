using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickLifeCoachingClinic.DTOs.DoctorDtoFolder;
using QuickLifeCoachingClinic.Services.MentorServices;

namespace QuickLifeCoachingClinic.Controllers
{
    [Route("api/mentors")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly IMentorService _mentorService;
        public MentorController(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MentorDto>>> GetAllMentorrsAsync()
        {
            var mentors = await _mentorService.GetMentorsAsync();
            return Ok(mentors);
        }

        [HttpGet("search/{specialization}")]
        public async Task<ActionResult<IEnumerable<MentorDto>>> GetMentorsBySpecializationAsync(
        [FromRoute] string specialization)
        {
            var mentors = await _mentorService.GetMentorsBySpecializationAsync(specialization);
            return Ok(mentors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MentorDto>> GetMentorByIdAsync([FromRoute] int id)
        {
            var mentor = await _mentorService.GetMentorByIdAsync(id);
            return Ok(mentor);
        }

        [HttpGet("{id}/certificates/")]
        public async Task<ActionResult> GetCertificates([FromRoute] int id)
        {
            var certificates = await _mentorService.GetCertificates(id);
            return certificates != null ? Ok(certificates) : BadRequest();
        }
    }
}
