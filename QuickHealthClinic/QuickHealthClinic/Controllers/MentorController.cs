using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickHealthClinic.DTOs.DoctorDtoFolder;
using QuickHealthClinic.Services.DoctorServices;

namespace QuickHealthClinic.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly IMentorService _doctorService;
        public MentorController(IMentorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MentorDto>>> GetAllDoctorsAsync()
        {
            var doctors = await _doctorService.GetMentorsAsync();
            return Ok(doctors);
        }

        [HttpGet("search/{specialization}")]
        public async Task<ActionResult<IEnumerable<MentorDto>>> GetDoctorsBySpecializationAsync(
        [FromRoute] string specialization)
        {
            var doctors = await _doctorService.GetMentorsBySpecializationAsync(specialization);
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MentorDto>> GetDoctorByIdAsync([FromRoute] int id)
        {
            var doctor = await _doctorService.GetMentorByIdAsync(id);
            return Ok(doctor);
        }
    }
}
