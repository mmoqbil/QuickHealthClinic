using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickHealthClinic.DTOs.DoctorDtoFolder;
using QuickHealthClinic.Services.DoctorServices;

namespace QuickHealthClinic.Controllers
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
            var doctors = await _mentorService.GetMentorsAsync();
            return Ok(doctors);
        }

        [HttpGet("search/{specialization}")]
        public async Task<ActionResult<IEnumerable<MentorDto>>> GetMentorsBySpecializationAsync(
        [FromRoute] string specialization)
        {
            var doctors = await _mentorService.GetMentorsBySpecializationAsync(specialization);
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MentorDto>> GetMentorByIdAsync([FromRoute] int id)
        {
            var doctor = await _mentorService.GetMentorByIdAsync(id);
            return Ok(doctor);
        }
    }
}
