﻿using Microsoft.AspNetCore.Mvc;
using QuickLifeCoachingClinic.DTOs.AccountDtoFolder;
using QuickLifeCoachingClinic.DTOs.StudentDtoFolder;
using QuickLifeCoachingClinic.Services.MentorServices;
using QuickLifeCoachingClinic.Services.StudentServices;

namespace QuickLifeCoachingClinic.Controllers
{
    [ApiController]
    [Route("/api/account")]
    public class AccountController : Controller
    {
        private readonly IMentorService _mentorService;
        private readonly IStudentService _studentService;
        public AccountController(IMentorService mentorService, IStudentService studentService)
        {
            _mentorService = mentorService;
            _studentService = studentService;
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

        [HttpPost("student/register")]
        public async Task<IActionResult> AddStudentAsync([FromBody] CreateStudentDto dto)
        {
            var (studentId, student) = await _studentService.CreateAsync(dto);
            return Created($"/api/students/{studentId}", student);
        }

        [HttpPut("student/{id}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] int id, [FromBody] UpdateStudentDto dto)
        {
            await _studentService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("student/{id}")]
        public async Task<IActionResult> DeleteStudentByIdAsync([FromRoute] int id)
        {
            await _studentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
