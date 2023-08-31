﻿using AutoMapper;
using QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces;
using QuickLifeCoachingClinic.DTOs.VisitDtoFolder;

namespace QuickLifeCoachingClinic.Services.VisitServices
{
    public class VisitService : IVisitService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
    }
}
