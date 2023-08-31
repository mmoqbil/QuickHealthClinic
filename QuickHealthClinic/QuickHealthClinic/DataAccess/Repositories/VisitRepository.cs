using Microsoft.EntityFrameworkCore;
using QuickLifeCoachingClinic.DataAccess.DbContexts;
using QuickLifeCoachingClinic.DataAccess.Entities;
using QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces;
using QuickLifeCoachingClinic.DTOs.VisitDtoFolder;

namespace QuickLifeCoachingClinic.DataAccess.Repositories
{
    public class VisitRepository : Repository<Visit>, IVisitRepository
    {
        public VisitRepository(QuickLifeCoachingClinicContext context) : base(context)
        {
            DbSet = context.Visits;
        }

        public async Task<IReadOnlyList<VisitCalendarDto>> GetVisitsForMonth(int mentorId, DateOnly date)
        {
            var visitDates = await DbSet
                .Where(visit => visit.MentorId == mentorId)
                .Where(visit => visit.VisitDate.Month == date.Month && visit.VisitDate.Year == date.Year)
                .Select(visit => visit.VisitDate)
                .ToListAsync();

            var visitCalendarDto = visitDates
                .GroupBy(visit => visit.Day)
                .Select(group => new VisitCalendarDto
                {
                    Day = group.Key,
                    Visits = group.Count()
                })
                .ToList();

            return visitCalendarDto;
        }
    }
}
