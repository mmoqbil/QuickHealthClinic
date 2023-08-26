using AutoMapper;
using QuickLifeCoachingClinic.DataAccess.Entities;
using QuickLifeCoachingClinic.DTOs.AccountDtoFolder;
using QuickLifeCoachingClinic.DTOs.ClinicDto;
using QuickLifeCoachingClinic.DTOs.DoctorDtoFolder;

namespace QuickLifeCoachingClinic.Configurations.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Mentor, MentorDto>()
                .ForMember(dto => dto.City, d => d.MapFrom(a => a.Address.City))
                .ForMember(dto => dto.Street, d => d.MapFrom(a => a.Address.Street))
                .ForMember(dto => dto.PostalCode, d => d.MapFrom(a => a.Address.PostalCode));

            CreateMap<CreateMentorDto, Mentor>()
                .ForMember(d => d.Address,
                    c => c.MapFrom(dto => new Address
                        { City = dto.City, Street = dto.Street, PostalCode = dto.PostalCode })).ReverseMap();

            CreateMap<UpdateMentorDto, Mentor>();

            CreateMap<Clinic, ClinicDto>()
            .ForMember(dto => dto.City, c => c.MapFrom(a => a.Address.City))
            .ForMember(dto => dto.Street, c => c.MapFrom(a => a.Address.Street))
            .ForMember(dto => dto.PostalCode, c => c.MapFrom(a => a.Address.PostalCode));
        }
    }
}
