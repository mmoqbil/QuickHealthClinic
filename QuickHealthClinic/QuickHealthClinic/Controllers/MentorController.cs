using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickLifeCoachingClinic.DTOs.DoctorDtoFolder;
using QuickLifeCoachingClinic.DTOs.ImageDto;
using QuickLifeCoachingClinic.Services.FileServices;
using QuickLifeCoachingClinic.Services.MentorServices;

namespace QuickLifeCoachingClinic.Controllers
{
    [Route("api/mentors")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly IMentorService _mentorService;
        private readonly IFileService _fileService;
        public MentorController(IMentorService mentorService, IFileService fileService)
        {
            _mentorService = mentorService;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MentorDto>>> GetAllMentorrsAsync()
        {
            var mentors = await _mentorService.GetMentorsAsync();
            return Ok(mentors);
        }

        [HttpGet("search/{specialization}")]
        public async Task<ActionResult<IEnumerable<MentorDto>>> GetMentorsBySpecializationAsync(
        [FromRoute] string specialization)
        {
            var mentors = await _mentorService.GetMentorsBySpecializationAsync(specialization);
            return Ok(mentors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MentorDto>> GetMentorByIdAsync([FromRoute] int id)
        {
            var mentor = await _mentorService.GetMentorByIdAsync(id);
            return Ok(mentor);
        }

        [HttpGet("{id}/certificates/")]
        public async Task<ActionResult> GetCertificates([FromRoute] int id)
        {
            var certificates = await _mentorService.GetCertificates(id);
            return certificates != null ? Ok(certificates) : BadRequest();
        }

        [HttpPost("{id}/certificates")]
        public async Task<ActionResult> UploadCertificate([FromRoute] int id, [FromForm] CreateImageDto file)
        {
            var filename = await _fileService.SaveFile(file);
            var result = await _mentorService.AddCertificate(filename, id);
            return result ? Ok(filename) : BadRequest();
        }
    }
}
