﻿using QuickLifeCoachingClinic.DataAccess.Entities;
using QuickLifeCoachingClinic.DTOs.VisitDtoFolder;

namespace QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces
{
    public interface IVisitRepository : IRepository<Visit>
    {
        Task<IReadOnlyList<VisitCalendarDto>> GetVisitsForMonth(int mentorId, DateOnly date);
    }
}
