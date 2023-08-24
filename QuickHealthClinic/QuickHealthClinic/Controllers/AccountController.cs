using Microsoft.AspNetCore.Mvc;
using QuickHealthClinic.DTOs.AccountDtoFolder;
using QuickHealthClinic.Services.DoctorServices;

namespace QuickHealthClinic.Controllers
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
        [HttpPost("doctor/register")]
        public async Task<IActionResult> AddDoctorAsync([FromBody] CreateMentorDto dto)
        {
            var (doctorId, doctor) = await _doctorService.CreateDoctorAsync(dto);
            return Created($"/api/doctors/{doctorId}", doctor);
        }
    }
}
