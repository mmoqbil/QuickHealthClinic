using AutoMapper;
using QuickHealthClinic.DataAccess.Entities;
using QuickHealthClinic.DTOs.AccountDtoFolder;
using QuickHealthClinic.DTOs.DoctorDtoFolder;

namespace QuickHealthClinic.Configurations.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorDto>();
            CreateMap<CreateDoctorDto, Doctor>();
        }
    }
}
