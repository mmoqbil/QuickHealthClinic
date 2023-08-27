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
            var clinics = await _clinicService.GetClinicAsync();
            return Ok(clinics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClinicDto>> GetClinicByIdAsync([FromRoute] int id)
        {
            var clinic = await _clinicService.GetClinicByIdAsync(id);
            return Ok(clinic);
        }
    }
}
