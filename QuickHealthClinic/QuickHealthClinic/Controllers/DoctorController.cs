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
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetAllDoctorsAsync()
        {
            var doctors = await _doctorService.GetDoctorsAsync();
            return Ok(doctors);
        }
        [HttpGet("search/{specialization}")]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctorsBySpecializationAsync(
        [FromRoute] string specialization)
        {
            return Ok();
        }
}
