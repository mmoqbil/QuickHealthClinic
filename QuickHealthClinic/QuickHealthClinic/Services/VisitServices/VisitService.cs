﻿using AutoMapper;
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

        public async Task<IEnumerable<VisitCalendarDto>> GetVisitsForMonth(int mentorId, DateOnly date)
        {
            return await _unitOfWork.VisitRepository.GetVisitsForMonth(mentorId, date);
        }
    }
}
