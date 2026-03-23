using AutoMapper;
using Presencehub.Application.Dto;
using Presencehub.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presencehub.Application.Mapper
{
    public class PresencehubProfile : Profile
    {
        public PresencehubProfile() 
        {
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<User, PostDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.UserDetails.FullName))
                .ForMember(dest => dest.DOB, opt => opt.MapFrom(src => src.UserDetails.DOB))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.UserDetails.Gender))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.UserDetails.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.UserDetails.Address))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.UserDetails.Department))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.UserDetails.Year))
                .ReverseMap();
            CreateMap<AttendanceDto, Attendance>().ReverseMap();


        }
    }
}
