using Microsoft.AspNetCore.Mvc;
using QuickLifeCoachingClinic.DTOs.AccountDtoFolder;
using QuickLifeCoachingClinic.Services.MentorServices;

namespace QuickLifeCoachingClinic.Controllers
{
    [ApiController]
    [Route("/api/account")]
    public class AccountController : Controller
    {
        private readonly IMentorService _mentorService;
        public AccountController(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        [HttpPost("mentor/register")]
        public async Task<IActionResult> AddDoctorAsync([FromBody] CreateMentorDto dto)
        {
            var (mentorId, mentor) = await _mentorService.CreateMentorAsync(dto);
            return Created($"/api/mentors/{mentorId}", mentor);
        }

        [HttpPut("mentor/{id}")]
        public async Task<IActionResult> UpdateDoctorAsync([FromRoute] int id, [FromBody] UpdateMentorDto dto)
        {
            await _mentorService.UpdateMentorAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("mentor/{id}")]
        public async Task<IActionResult> DeleteMentorByIdAsync([FromRoute] int id)
        {
            await _mentorService.DeleteMentorAsync(id);
            return NoContent();
        }
    }
}
