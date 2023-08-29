using Microsoft.AspNetCore.Mvc;
using QuickLifeCoachingClinic.DTOs.ClinicDtoFolder;
using QuickLifeCoachingClinic.Services.ClinicService;

namespace QuickLifeCoachingClinic.Controllers
{
    [ApiController]
    [Route("/api/clinics")]
    public class ClinicController : Controller
    {
        private readonly IClinicService _clinicService;

        public ClinicController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClinicDto>>> GetAllClinicsAsync()
        {
            var clinics = await _clinicService.GetAsync();
            return Ok(clinics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClinicDto>> GetClinicByIdAsync([FromRoute] int id)
        {
            var clinic = await _clinicService.GetByIdAsync(id);
            return Ok(clinic);
        }

        [HttpGet("{id}/mentors")]
        public async Task<ActionResult<IEnumerable<ClinicMentorDto>>> GetAllDoctorsAsync([FromRoute] int id)
        {
            var mentors = await _clinicService.GetMentorsAsync(id);
            return Ok(mentors);
        }

        [HttpPost]
        public async Task<IActionResult> AddClinicAsync([FromBody] CreateClinicDto dto)
        {
            var (clinicId, clinic) = await _clinicService.CreateAsync(dto);
            return Created($"/api/clinics/{clinicId}", clinic);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClinicsAsync([FromRoute] int id, [FromBody] UpdateClinicDto dto)
        {
            await _clinicService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClinicByIdAsync([FromRoute] int id)
        {
            await _clinicService.DeleteAsync(id);
            return NoContent();
        }
    }
}
