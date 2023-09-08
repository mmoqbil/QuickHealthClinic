using AutoMapper;
using QuickLifeCoachingClinic.DataAccess.Entities;
using QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces;
using QuickLifeCoachingClinic.DTOs.VisitDtoFolder;

namespace QuickLifeCoachingClinic.Services.VisitServices
{
    public class VisitService : IVisitService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VisitService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AcceptVisit(int visitId)
        {
            var visit = await _unitOfWork.VisitRepository.GetAsync(visitId);
            if (visit == null) return false;

            visit.Confirmed = true;
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> DeclineVisit(int visitId)
        {
            var visit = await _unitOfWork.VisitRepository.GetAsync(visitId);
            if (visit == null) return false;

            visit.Confirmed = false;
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<VisitCalendarDto>> GetVisitsForMonth(int mentorId, DateOnly date)
        {
            return await _unitOfWork.VisitRepository.GetVisitsForMonth(mentorId, date);
        }

        public async Task<IEnumerable<VisitDTO>> GetVisitsByMentorIdAsync(int id)
        {
            var visits = await _unitOfWork.VisitRepository.GetAllAsync(
                v => v.MentorId.Equals(id),
                visits => visits.OrderBy(v => v.VisitDate),
                "Mentor");

            var visitsDTO = visits.Select(v => new VisitDTO
            {
                Id = v.Id,
                Duration = v.Duration,
                StudentId = v.StudentId,
                Student = $"{v.Student.FirstName} {v.Student.LastName}",
                Treatment = v.Name,
                Confirmed = v.Confirmed,
                StartDate = new DateTimeOffset(v.VisitDate).ToUnixTimeSeconds()
            });
            return visitsDTO;
        }

        public async Task<IEnumerable<VisitStudentDto>> GetVisitsByStudentIdAsync(int id)
        {
            var visits = await _unitOfWork.VisitRepository.GetAllAsync(
                v => v.StudentId.Equals(id),
                visits => visits.OrderBy(v => v.VisitDate),
                "Doctor");

            var visitsDTO = visits.Select(v => new VisitStudentDto
            {
                Id = v.Id,
                Duration = v.Duration,
                MentorId = v.MentorId,
                Mentor = $"{v.Mentor.FirstName} {v.Mentor.LastName}",
                Treatment = v.Name,
                StartDate = new DateTimeOffset(v.VisitDate).ToUnixTimeSeconds()
            }
            );

            return visitsDTO;
        }

        public async Task<(int, CreateVisitDto)> CreateVisitAsync(CreateVisitDto visitDto)
        {
            var visit = new Visit
            {
                Name = visitDto.Name,
                MentorId = visitDto.MentorId,
                StudentId = visitDto.StudentId,
                VisitDate = visitDto.VisitDate,
                Duration = visitDto.Duration,
                Confirmed = false
            };

            await _unitOfWork.VisitRepository.AddAsync(visit);
            await _unitOfWork.SaveAsync();

            var createdVisitDto = new CreateVisitDto
            {
                Name = visit.Name,
                MentorId = visit.MentorId,
                StudentId = visit.StudentId,
                VisitDate = visit.VisitDate,
                Duration = visit.Duration
            };


            await _unitOfWork.VisitRepository.AddAsync(visit);
            await _unitOfWork.SaveAsync();
            return (visit.Id, createdVisitDto);
        }


    }
}
