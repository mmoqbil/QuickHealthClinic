using AutoMapper;
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
        public Task<IEnumerable<DoctorDto>> GetDoctorsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
