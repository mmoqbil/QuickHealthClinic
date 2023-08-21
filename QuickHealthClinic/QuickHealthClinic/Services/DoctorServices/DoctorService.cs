﻿using AutoMapper;
using QuickHealthClinic.DataAccess.DbContexts;
using QuickHealthClinic.DataAccess.Repositories.Interfaces;
using QuickHealthClinic.DTOs.DoctorDtoFolder;

namespace QuickHealthClinic.Services.DoctorServices
{
    public class DoctorService : IDoctorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly QuickHealthClinicContext _context;
        public DoctorService(IUnitOfWork unitOfWork, IMapper mapper, QuickHealthClinicContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<DoctorDto>> GetDoctorsAsync() 
        {
            var doctors = await _unitOfWork.DoctorRepository.GetAllAsync();

            var doctorsDto = _mapper.Map<List<DoctorDto>>(doctors);

            return doctorsDto;
        }
    }
}