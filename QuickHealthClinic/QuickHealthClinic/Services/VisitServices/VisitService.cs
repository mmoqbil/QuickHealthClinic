using AutoMapper;
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
    }
}
