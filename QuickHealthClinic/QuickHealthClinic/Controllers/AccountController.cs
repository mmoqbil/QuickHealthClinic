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
            var (doctorId, doctor) = await _doctorService.CreateMentorAsync(dto);
            return Created($"/api/doctors/{doctorId}", doctor);
        }

    }
}
