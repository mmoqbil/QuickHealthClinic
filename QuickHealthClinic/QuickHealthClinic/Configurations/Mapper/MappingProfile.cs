﻿using AutoMapper;
using QuickHealthClinic.DataAccess.Entities;
using QuickHealthClinic.DTOs.AccountDtoFolder;
using QuickHealthClinic.DTOs.DoctorDtoFolder;

namespace QuickHealthClinic.Configurations.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorDto>()
                .ForMember(dto => dto.City, d => d.MapFrom(a => a.Address.City))
                .ForMember(dto => dto.Street, d => d.MapFrom(a => a.Address.Street))
                .ForMember(dto => dto.PostalCode, d => d.MapFrom(a => a.Address.PostalCode));

            CreateMap<CreateDoctorDto, Doctor>()
                .ForMember(d => d.Address,
                    c => c.MapFrom(dto => new Address
                        { City = dto.City, Street = dto.Street, PostalCode = dto.PostalCode })).ReverseMap();

            CreateMap<UpdateDoctorDto, Doctor>();
        }
    }
}
