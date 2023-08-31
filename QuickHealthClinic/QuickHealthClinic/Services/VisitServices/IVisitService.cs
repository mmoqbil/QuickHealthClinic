using QuickLifeCoachingClinic.DTOs.VisitDtoFolder;

namespace QuickLifeCoachingClinic.Services.VisitServices
{
    public interface IVisitService
    {
        Task<IEnumerable<VisitCalendarDto>> GetVisitsForMonth(int mentorId, DateOnly date);
    }
}
