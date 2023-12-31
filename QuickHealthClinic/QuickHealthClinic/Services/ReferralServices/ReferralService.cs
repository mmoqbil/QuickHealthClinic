﻿using AutoMapper;
using QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces;
using QuickLifeCoachingClinic.DTOs.ReferralDtoFolder;

namespace QuickLifeCoachingClinic.Services.ReferralServices
{
    public class ReferralService : IReferralService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReferralService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ReferralDto>> GetIdAsync(int id)
        {
            var referrals = await _unitOfWork.ReferralRepository
             .GetAllAsync(r => r.StudentId == id, includeProperties: "Student");

            var referralsDto = referrals.Select(r => new ReferralDto
            {
                Id = r.Id,
                StudentId = r.StudentId,
                Student = $"{r.Student.FirstName} {r.Student.LastName}",
                Date = new DateTimeOffset(r.Created).ToUnixTimeSeconds(),
                Specialist = r.Specialist,
                Description = r.Description,
                Code = r.Code
            });

            return referralsDto;
        }
    }
}
