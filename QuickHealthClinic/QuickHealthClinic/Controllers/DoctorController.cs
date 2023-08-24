using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickHealthClinic.DTOs.DoctorDtoFolder;
using QuickHealthClinic.Services.DoctorServices;

namespace QuickHealthClinic.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMentorService _doctorService;
        public DoctorController(IMentorService doctorService)
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
            var doctors = await _doctorService.GetDoctorsBySpecializationAsync(specialization);
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MentorDto>> GetDoctorByIdAsync([FromRoute] int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            return Ok(doctor);
        }
    }
}
