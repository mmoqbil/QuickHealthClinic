using Microsoft.AspNetCore.Mvc;
using QuickLifeCoachingClinic.DTOs.AccountDtoFolder;
using QuickLifeCoachingClinic.Services.MentorServices;

namespace QuickLifeCoachingClinic.Controllers
{
    [ApiController]
    [Route("/api/account")]
    public class AccountController : Controller
    {
        private readonly IMentorService _doctorService;
        public AccountController(IMentorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost("mentor/register")]
        public async Task<IActionResult> AddDoctorAsync([FromBody] CreateMentorDto dto)
        {
            var (mentorId, mentor) = await _doctorService.CreateMentorAsync(dto);
            return Created($"/api/mentors/{mentorId}", mentor);
        }

        [HttpPut("mentor/{id}")]
        public async Task<IActionResult> UpdateDoctorAsync([FromRoute] int id, [FromBody] UpdateMentorDto dto)
        {
            await _doctorService.UpdateMentorAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("mentor/{id}")]
        public async Task<IActionResult> DeleteDoctorByIdAsync([FromRoute] int id)
        {
            await _doctorService.DeleteMentorAsync(id);
            return NoContent();
        }
    }
}
