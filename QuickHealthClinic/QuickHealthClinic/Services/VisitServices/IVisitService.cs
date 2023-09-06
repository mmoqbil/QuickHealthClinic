using QuickLifeCoachingClinic.DataAccess.Entities;
using QuickLifeCoachingClinic.DTOs.VisitDtoFolder;

namespace QuickLifeCoachingClinic.Services.VisitServices
{
    public interface IVisitService
    {
        Task<bool> AcceptVisit(int visitId);
        Task<bool> DeclineVisit(int visitId);
        Task<IEnumerable<VisitCalendarDto>> GetVisitsForMonth(int mentorId, DateOnly date);

    }
}
