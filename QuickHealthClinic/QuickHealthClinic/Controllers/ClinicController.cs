using Microsoft.AspNetCore.Mvc;
using QuickLifeCoachingClinic.DTOs.ClinicDto;
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
            var clinics = await _clinicService.GetClinicsAsync();
            return Ok(clinics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClinicDto>> GetClinicByIdAsync([FromRoute] int id)
        {
            var clinic = await _clinicService.GetClinicByIdAsync(id);
            return Ok(clinic);
        }

        [HttpPost]
        public async Task<IActionResult> AddClinicAsync([FromBody] CreateClinicDto dto)
        {
            var (clinicId, clinic) = await _clinicService.CreateClinicAsync(dto);
            return Created($"/api/clinics/{clinicId}", clinic);
        }
    }
}
